﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ssi
{
    public partial class MainHandler
    {

        //Config
        public static string BuildVersion = "0.9.9.9.7";
        public static MEDIABACKEND Mediabackend = MEDIABACKEND.MEDIAKIT;




        private static Timeline timeline = null;

        public enum SSI_FILE_TYPE
        {
            UNKOWN = 0,
            CSV,
            AUDIO,
            VIDEO,
            ANNO,
            ANNOTATION,
            STREAM,
            EVENTS,
            EAF,
            ANVIL,
            ARFF,
            PROJECT,
            IGNORE
        }

        public static readonly string[] SSIFileTypeNames = { "ssi", "audio", "video", "anno", "stream", "events", "eaf", "anvil", "vui", "arff", "annotation" };

        private MainControl control;

        public static Timeline Time
        {
            get { return timeline; }
        }

        public Cursor signalCursor = null;
        public Cursor annoCursor = null;

        public static List<SignalTrack> signalTracks = new List<SignalTrack>();
        public static List<Signal> signals = new List<Signal>();
        public static List<AnnoTier> annoTiers = new List<AnnoTier>();
        public static List<AnnoList> annoLists = new List<AnnoList>();
        public static MediaList mediaList = new MediaList();
        public static List<MediaBox> mediaBoxes = new List<MediaBox>();

        private bool playIsPlaying = false;
        private double playSampleRate = Defaults.DefaultSampleRate;
        private int playLastTick = 0;
        private DispatcherTimer playTimer = null;

        private bool isMouseButtonDown = false;
        private bool isKeyDown = false;
        private string lastDownloadFileName = null;

        public List<string> databaseSessionStreams;

        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        public AnnoTierSegment temp_segment;

        public class DownloadStatus
        {
            public string File;
            public double percent;
            public bool active;
        }

        public List<AnnoTier> AnnoTiers
        {
            get { return annoTiers; }
        }

        public AnnoTier getAnnoTierFromName(string name)
        {
            foreach (AnnoTier anno in annoTiers)
            {
                if (anno.AnnoList.Scheme.Name == name)
                {
                    return anno;
                }
            }

            return null;
        }

        public MainHandler(MainControl view)
        {
            control = view;
            control.Drop += controlDrop;

            // Shadow box

            control.shadowBoxCancelButton.Click += shadowBoxCancel_Click;

            // Media

            control.mediaStatusBar.Background = Defaults.Brushes.Highlight;
            MediaBoxStatic.OnBoxChange += onMediaBoxChange;
            control.mediaVolumeControl.volumeSlider.ValueChanged += mediaVolumeControl_ValueChanged;
            control.mediaCloseButton.Click += mediaBoxCloseButton_Click;

            // Signal

            control.signalStatusBar.Background = Defaults.Brushes.Highlight;
            control.signalSettingsButton.Click += signalSettingsButton_Click;
            control.signalStatsButton.Click += signalStatsButton_Click;
            control.signalStatusDimComboBox.SelectionChanged += signalDimComboBox_SelectionChanged;
            control.signalStatusDimComboBox.SelectionChanged += signalDimComboBox_SelectionChanged;
            control.signalVolumeControl.volumeSlider.ValueChanged += signalVolumeControl_ValueChanged;
            control.signalCloseButton.Click += signalTrackCloseButton_Click;
            SignalTrackStatic.OnTrackChange += onSignalTrackChange;
            control.signalAndAnnoGrid.MouseDown += signalAndAnnoGrid_MouseDown;

            // Anno

            control.annoStatusBar.Background = Defaults.Brushes.Highlight;
            control.annoCloseButton.Click += annoTierCloseButton_Click;
            control.annoSettingsButton.Click += annoSettingsButton_Click;
            control.annoListControl.annoDataGrid.SelectionChanged += annoList_SelectionChanged;
            control.annoListControl.editButton.Click += annoListEdit_Click;
            control.annoListControl.editTextBox.KeyDown += annoListEdit_KeyDown;
            control.annoListControl.editTextBox.GotMouseCapture += annoListEdit_Focused;
            AnnoTierStatic.OnTierChange += onAnnoTierChange;
            AnnoTierStatic.OnTierSegmentChange += changeAnnoTierSegmentHandler;
            control.annoTierControl.MouseDown += annoTierControl_MouseDown;
            control.annoTierControl.MouseMove += annoTierControl_MouseMove;
            control.annoTierControl.MouseUp += annoTierControl_MouseRightButtonUp;
            control.annoLiveModeCheckBox.Checked += annoLiveMode_Changed;
            control.annoLiveModeCheckBox.Unchecked += annoLiveMode_Changed;
            control.annoLiveModeActivateMouse.Checked += annoLiveModeActiveMouse_Checked;
            control.annoLiveModeActivateMouse.Unchecked += annoLiveModeActiveMouse_Unchecked;

            // Geometric

            control.geometricListControl.editButton.Click += geometricListEdit_Click;
            control.geometricListControl.editTextBox.GotMouseCapture += geometricListEdit_Focused;
            control.geometricListControl.copyButton.Click += geometricListCopy_Click;
            control.geometricListControl.selectAllButton.Click += geometricListSelectAll_Click;
            control.geometricListControl.geometricDataGrid.SelectionChanged += geometricList_Selection;
            control.geometricListControl.MenuItemDeleteClick.Click += geometricListDelete;
            control.geometricListControl.KeyDown += geometricKeyDown;
            control.geometricListControl.Visibility = Visibility.Collapsed;

            // Menu

            control.menu.MouseEnter += tierMenu_MouseEnter;

            control.annoSaveMenu.Click += annoSave_Click;
            control.annoReloadMenu.Click += annoReload_Click;
            control.annoReloadBackupMenu.Click += annoReloadBackup_Click;
            control.annoExportMenu.Click += annoExport_Click;
            control.annoSaveAllMenu.Click += annoSaveAll_Click;

            control.loadFilesMenu.Click += loadFiles_Click;
            control.fileSaveProjectMenu.Click += fileSaveProject_Click;
            control.fileLoadProjectMenu.Click += fileLoadProject_Click;                 

            control.exportSamplesMenu.Click += exportSamples_Click;
            control.exportToGenie.Click += exportToGenie_Click;
            control.exportTierToXPSMenu.Click += exportTierToXPS_Click;
            control.exportTierToPNGMenu.Click += exportTierToPNG_Click;
            control.exportSignalToXPSMenu.Click += exportSignalToXPS_Click;
            control.exportSignalToPNGMenu.Click += exportSignalToPNG_Click;
            control.exportAnnoToCSVMenu.Click += exportAnnoToCSV_Click;

            control.convertAnnoContinuousToDiscreteMenu.Click += convertAnnoContinuousToDiscrete_Click;
            control.convertAnnoToSignalMenu.Click += convertAnnoToSignal_Click;
            control.convertSignalToAnnoContinuousMenu.Click += convertSignalToAnnoContinuous_Click;
            
            control.databaseLoadSessionMenu.Click += databaseLoadSession_Click;
            control.databaseCMLCompleteStepMenu.Click += databaseCMLCompleteStep_Click;
            control.databaseCMLExtractFeaturesMenu.Click += databaseCMLExtractFeatures_Click;
            control.databaseCMLTrainMenu.Click += databaseCMLTrain_Click;
            control.databaseCMLPredictMenu.Click += databaseCMLPredict_Click;
            control.databaseManageUsersMenu.Click += databaseManageUsers_Click;
            control.databaseManageDBsMenu.Click += databaseManageDBs_Click;
            control.databaseManageSessionsMenu.Click += databaseManageSessions_Click;
            control.databaseManageAnnotationsMenu.Click += databaseManageAnnotations_Click;
            control.databaseCMLMergeMenu.Click += databaseCMLMerge_Click;

            control.showSettingsMenu.Click += showSettings_Click;

            control.helpDocumentationMenu.Click += helpDocumentationMenu_Click;
            control.helpShortcutsMenu.Click += helpShortcutsMenu_Click;
            control.updateApplicationMenu.Click += updateApplication_Click;
            control.updateCMLMenu.Click += updateCML_Click;

            // Navigator

            control.navigator.newAnnoFromFileButton.Click += navigatorNewAnnoFromFile_Click;
            control.navigator.newAnnoFromDatabaseButton.Click += navigatorNewAnnoFromDatabase_Click;
            control.navigator.clearButton.Click += navigatorClearSession_Click;
            control.navigator.jumpFrontButton.Click += navigatorJumpFront_Click;
            control.navigator.playButton.Click += navigatorPlay_Click;
            control.navigator.jumpEndButton.Click += navigatorJumpEnd_Click;

            control.navigator.fastForwardButton.Click += fastForwardButton_Click;
            control.navigator.fastBackwardButton.Click += fastBackwardButton_Click;


            // Timeline

            timeline = new Timeline();
            timeline.SelectionInPixel = control.signalAndAnnoAdorner.ActualWidth;
            control.signalAndAnnoAdorner.SizeChanged += signalAndAnnoControlSizeChanged;
            control.timeLineControl.rangeSlider.OnTimeRangeChanged += control.timeLineControl.timeTrack.TimeRangeChanged;
            control.timeLineControl.rangeSlider.OnTimeRangeChanged += control.timeLineControl.timeTrackSelection.TimeRangeChanged;
            control.timeLineControl.rangeSlider.OnTimeRangeChanged += Time.TimelineChanged;
            control.timeLineControl.rangeSlider.Update();



            // Database

            control.databaseConnectMenu.Click += DatabaseConnectMenu_Click;
            if (Properties.Settings.Default.DatabaseAutoLogin)
            {
                databaseConnect();
            }
            else
            {
                updateNavigator();
            }


            // Mouse

            control.MouseWheel += (sender, args) =>
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    if (args.Delta > 0)
                    {
                        control.timeLineControl.rangeSlider.MoveAndUpdate(true, 0.2f);
                    }
                    else if (args.Delta < 0)
                    {
                        control.timeLineControl.rangeSlider.MoveAndUpdate(false, 0.2f);
                    }
                }
            };

            // Player

            playTimer = new DispatcherTimer();
            playTimer.Tick += PlayTimer_Tick;

            // Cursor

            initCursor();

            // Update

            if (Properties.Settings.Default.CheckUpdateOnStart && Properties.Settings.Default.LastUpdateCheckDate.Date != DateTime.Today.Date)
            {
                Properties.Settings.Default.LastUpdateCheckDate = DateTime.Today.Date;
                Properties.Settings.Default.Save();
                checkForUpdates(true);
            }


            //Download Hardware Video Acceleration Library, if not present yet.
            string hardwareAcceleratorLibrary = "EVRPresenter64.dll";
            string hardwareAcceleratorLibraryPath = AppDomain.CurrentDomain.BaseDirectory + hardwareAcceleratorLibrary;

            if (!(File.Exists(hardwareAcceleratorLibraryPath)))
            {
                
                DownloadFile("https://github.com/hcmlab/nova/raw/master/" + hardwareAcceleratorLibrary, hardwareAcceleratorLibraryPath);

            }

            string cmltrainexe = "cmltrain.exe";
            string cmltrainexePath = AppDomain.CurrentDomain.BaseDirectory + cmltrainexe;

            if (!(File.Exists(cmltrainexePath)))
            {

                updateCML();

            }


            if (Properties.Settings.Default.DatabaseDirectory == "")
            {                
                Properties.Settings.Default.DatabaseDirectory = Directory.GetCurrentDirectory() + "\\data";
                Properties.Settings.Default.Save();
                Directory.CreateDirectory(Properties.Settings.Default.DatabaseDirectory);
            }


            if (Properties.Settings.Default.CMLDirectory == "")
            {
                Properties.Settings.Default.CMLDirectory = Directory.GetCurrentDirectory() + "\\cml";
                Properties.Settings.Default.Save();
                Directory.CreateDirectory(Properties.Settings.Default.CMLDirectory);
            }



            // Clear

            clearSignalInfo();
            clearAnnoInfo();
            clearMediaBox();
        }

        /// <summary>
        /// 
        /// </summary>
        private void updateCML()
        {

            /*
           * CMLTrain and XMLchain executables are downloaded from the official SSI git repository.
           * */

            string SSIbinaryGitPath = "https://github.com/hcmlab/ssi/raw/master/bin/x64/vc140/";

            //Download CMLtrain, if not present yet.
            string cmltrainexe = "cmltrain.exe";
            string cmltrainexePath = AppDomain.CurrentDomain.BaseDirectory + cmltrainexe;

            try
            {
                DownloadFile(SSIbinaryGitPath + cmltrainexe, cmltrainexePath);
            }
            catch {
                MessageBox.Show("Can't update tools, check your internet conenction!");
                return;
            }


            //Download xmlchain, if not present yet.
            string xmlchainexe = "xmlchain.exe";
            string xmlchainexePath = AppDomain.CurrentDomain.BaseDirectory + xmlchainexe;

            DownloadFile(SSIbinaryGitPath + xmlchainexe, xmlchainexePath);

            //Download libmongoc-1.0.dll, if not present yet.
            string libmongocdll = "libmongoc-1.0.dll";
            string libmongocdllPath = AppDomain.CurrentDomain.BaseDirectory + libmongocdll;

            DownloadFile(SSIbinaryGitPath + libmongocdll, libmongocdllPath);


            //Download libbson-1.0.dll, if not present yet.
            string libsondll = "libbson-1.0.dll";
            string libbsondllPath = AppDomain.CurrentDomain.BaseDirectory + libsondll;

            DownloadFile(SSIbinaryGitPath + libsondll, libbsondllPath);

            //Download ssiframe.dll, if not present yet.
            string ssiframedll = "ssiframe.dll";
            string ssiframedllPath = AppDomain.CurrentDomain.BaseDirectory + ssiframedll;

            DownloadFile(SSIbinaryGitPath + ssiframedll, ssiframedllPath);





            if (File.Exists(xmlchainexePath) && File.Exists(cmltrainexePath) && File.Exists(libmongocdllPath) && File.Exists(libbsondllPath))
            {

                long sizexmlchain = new System.IO.FileInfo(xmlchainexePath).Length;
                long sizecmltrain = new System.IO.FileInfo(cmltrainexePath).Length;
                long sizelibmongocdll = new System.IO.FileInfo(libmongocdllPath).Length;
                long sizelibsondll = new System.IO.FileInfo(libbsondllPath).Length;
                long sizessiframedll = new System.IO.FileInfo(ssiframedllPath).Length;

                if (sizexmlchain == 0 || sizecmltrain == 0 || sizelibmongocdll == 0 || sizelibsondll == 0)
                {
                    if (File.Exists(xmlchainexePath)) File.Delete(xmlchainexePath);
                    if (File.Exists(cmltrainexePath)) File.Delete(cmltrainexePath);
                    if (File.Exists(libmongocdllPath)) File.Delete(libmongocdllPath);
                    if (File.Exists(libbsondllPath)) File.Delete(libbsondllPath);
                    if (File.Exists(ssiframedllPath)) File.Delete(ssiframedllPath);
                    MessageBox.Show("Could not update Cooperative Machine Learning Tools");
                }
                else MessageBox.Show("Successfully updated Cooperative Machine Learning Tools");
            }

        }




        private void signalAndAnnoControlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            timeline.SelectionInPixel = control.signalAndAnnoAdorner.ActualWidth;
            control.timeLineControl.rangeSlider.Update();
        }

        public void updateControl()
        {
            updateNavigator();
            updateSignalTrack(SignalTrackStatic.Selected);
            updateMediaBox(MediaBoxStatic.Selected);
            updateAnnoInfo(AnnoTierStatic.Selected);
        }

        public bool clearWorkspace()
        {
            tokenSource.Cancel();
            Stop();

            bool anytrackchanged = false;
            foreach (AnnoTier track in annoTiers)
            {
                if (track.AnnoList.HasChanged) anytrackchanged = true;
            }

            if (annoTiers.Count > 0 && anytrackchanged)
            {
                MessageBoxResult mbx = MessageBox.Show("There are unsaved changes, save all annotations?", "Question", MessageBoxButton.YesNoCancel);
                if (mbx == MessageBoxResult.Cancel)
                {
                    return false;
                }
                else if (mbx == MessageBoxResult.Yes)
                {
                    saveAllAnnos();
                }
                else if (mbx == MessageBoxResult.No)
                {
                    foreach (AnnoTier track in annoTiers)
                    {
                        track.AnnoList.HasChanged = false;
                    }
                }
            }

            if (Time.TotalDuration > 0) fixTimeRange(Properties.Settings.Default.DefaultZoomInSeconds);

            while (mediaBoxes.Count > 0)
            {
                removeMediaBox(mediaBoxes[0]);
            }
            mediaList.Clear();
            while (signalTracks.Count > 0)
            {
                removeSignalTrack(signalTracks[0]);
            }
            while (annoTiers.Count > 0)
            {
                removeAnnoTier(annoTiers[0]);
            }
            annoLists.Clear();
            setAnnoList(null);

            signalCursor.X = 0;
            Time.TotalDuration = 0;
            Time.SelectionStart = 0;
            Time.CurrentPlayPosition = 0;

            if (DatabaseHandler.IsSession)
            {
                DatabaseHandler.ChangeSession(null);
            }

            updateControl();
            control.timeLineControl.rangeSlider.Update();
            control.geometricListControl.Visibility = Visibility.Collapsed;

            return true;
        }

        private void updatePositionLabels(double time)
        {
            if (SignalTrackStatic.Selected != null && SignalTrackStatic.Selected.Signal != null)
            {
                Signal signal = SignalTrackStatic.Selected.Signal;
                control.signalPositionLabel.Text = FileTools.FormatSeconds(time);
                control.signalStatusValueLabel.Text = signal.Value(time).ToString();
                control.signalStatusValueMinLabel.Text = "min " + signal.min[signal.ShowDim].ToString();
                control.signalStatusValueMaxLabel.Text = "max " + signal.max[signal.ShowDim].ToString();
            }
            if (MediaBoxStatic.Selected != null && MediaBoxStatic.Selected.Media != null)
            {
                control.mediaPositionLabel.Text = "#" + FileTools.FormatFrames(time, MediaBoxStatic.Selected.Media.GetSampleRate());
            }
        }

        private void updateTimeRange(double duration)
        {
            if (duration > Time.TotalDuration)
            {
                Time.TotalDuration = duration;
                control.timeLineControl.rangeSlider.Update();
            }
        }

        private void fixTimeRange(double duration)
        {
            control.timeLineControl.rangeSlider.UpdateFixedRange(duration);
        }

        private void controlDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                if (filenames != null)
                {
                    loadMultipleFilesOrDirectory(filenames);
                }
            }
        }

        private void shadowBoxCancel_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }

        public void loadFiles()
        {
            string[] filenames = FileTools.OpenFileDialog("Viewable files|*.stream;*.csv;*.annotation;*.wav;*.avi;*.wmv;*mp4;*mpg;*mkv|Signal files (*.stream,*.csv)|*.stream;*.csv|Annotation files (*.annotation)|*annotation|Wave files (*.wav)|*.wav|Video files(*.avi,*.wmv,*.mp4;*.mov)|*.avi;*.wmv;*.mp4;*.mov|All files (*.*)|*.*", true);
            if (filenames != null)
            {
                control.Cursor = Cursors.Wait;
                loadMultipleFilesOrDirectory(filenames);
                control.Cursor = Cursors.Arrow;
            }
        }

        private void annoSaveAll_Click(object sender, RoutedEventArgs e)
        {
            saveAllAnnos();
        }


        private bool showDialogClearWorkspace(Window dialog)
        {
            if (DatabaseHandler.IsSession)
            {
                MessageBoxResult result = MessageBox.Show("The workspace will be cleared. Do you want to continue?", "Question", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    return false;
                }
                clearWorkspace();
            }
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
            return true;

        }

        private void showSettings()
        {
            Settings s = new Settings();
            s.Tab.SelectedIndex = 0;
            s.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            s.ShowDialog();

            if (s.DialogResult == true)
            {
                bool reconnect = false;

                if (Properties.Settings.Default.MongoDBUser != s.MongoUser()
                    || Properties.Settings.Default.DatabaseAddress != s.DatabaseAddress()
                    || Properties.Settings.Default.MongoDBPass != s.MongoPass())
                {
                    reconnect = true;
                }


                Properties.Settings.Default.UncertaintyLevel = s.Uncertainty();
                Properties.Settings.Default.Annotator = s.AnnotatorName();
                Properties.Settings.Default.DatabaseAddress = s.DatabaseAddress();
                Properties.Settings.Default.MongoDBUser = s.MongoUser();
                Properties.Settings.Default.MongoDBPass = s.MongoPass();
                Properties.Settings.Default.DatabaseAutoLogin= s.DBAutoConnect();
                Properties.Settings.Default.DefaultZoomInSeconds = double.Parse(s.ZoomInseconds());
                Properties.Settings.Default.DefaultMinSegmentSize = double.Parse(s.SegmentMinDur());
                Properties.Settings.Default.DefaultDiscreteSampleRate = double.Parse(s.SampleRate());
                Properties.Settings.Default.CheckUpdateOnStart = s.CheckforUpdatesonStartup();
                Properties.Settings.Default.ContinuousHotkeysNumber = int.Parse(s.ContinuousHotkeyLevels());
                Properties.Settings.Default.DatabaseAskBeforeOverwrite = s.DBAskforOverwrite();
                Properties.Settings.Default.Save();
                

                foreach(AnnoTier tier in AnnoTiers)
                {
                    tier.TimeRangeChanged(MainHandler.Time);
                }

                if (reconnect)
                {                    
                    databaseConnect();
                }

            }

        }

        private void showSettings_Click(object sender, RoutedEventArgs e)
        {
            showSettings();
        }
    }
}