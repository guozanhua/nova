﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ssi.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("login")]
        public string MongoDBUser {
            get {
                return ((string)(this["MongoDBUser"]));
            }
            set {
                this["MongoDBUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("password")]
        public string MongoDBPass {
            get {
                return ((string)(this["MongoDBPass"]));
            }
            set {
                this["MongoDBPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sftp.server.yeah")]
        public string DataServer {
            get {
                return ((string)(this["DataServer"]));
            }
            set {
                this["DataServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/path/to/your/files/")]
        public string DataServerFolder {
            get {
                return ((string)(this["DataServerFolder"]));
            }
            set {
                this["DataServerFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DataServerLogin {
            get {
                return ((string)(this["DataServerLogin"]));
            }
            set {
                this["DataServerLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DataServerPass {
            get {
                return ((string)(this["DataServerPass"]));
            }
            set {
                this["DataServerPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sftp")]
        public string DataServerConnectionType {
            get {
                return ((string)(this["DataServerConnectionType"]));
            }
            set {
                this["DataServerConnectionType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastSessionId {
            get {
                return ((string)(this["LastSessionId"]));
            }
            set {
                this["LastSessionId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost:27017")]
        public string DatabaseAddress {
            get {
                return ((string)(this["DatabaseAddress"]));
            }
            set {
                this["DatabaseAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseName {
            get {
                return ((string)(this["DatabaseName"]));
            }
            set {
                this["DatabaseName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseDirectory {
            get {
                return ((string)(this["DatabaseDirectory"]));
            }
            set {
                this["DatabaseDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DatabaseAutoLogin {
            get {
                return ((bool)(this["DatabaseAutoLogin"]));
            }
            set {
                this["DatabaseAutoLogin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.7")]
        public double UncertaintyLevel {
            get {
                return ((double)(this["UncertaintyLevel"]));
            }
            set {
                this["UncertaintyLevel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Annotator")]
        public string Annotator {
            get {
                return ((string)(this["Annotator"]));
            }
            set {
                this["Annotator"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public double DefaultZoomInSeconds {
            get {
                return ((double)(this["DefaultZoomInSeconds"]));
            }
            set {
                this["DefaultZoomInSeconds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1")]
        public double DefaultMinSegmentSize {
            get {
                return ((double)(this["DefaultMinSegmentSize"]));
            }
            set {
                this["DefaultMinSegmentSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25")]
        public double DefaultDiscreteSampleRate {
            get {
                return ((double)(this["DefaultDiscreteSampleRate"]));
            }
            set {
                this["DefaultDiscreteSampleRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DatabaseShowOnlyMine {
            get {
                return ((bool)(this["DatabaseShowOnlyMine"]));
            }
            set {
                this["DatabaseShowOnlyMine"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DatabaseShowOnlyFinished {
            get {
                return ((bool)(this["DatabaseShowOnlyFinished"]));
            }
            set {
                this["DatabaseShowOnlyFinished"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int CMLContext {
            get {
                return ((int)(this["CMLContext"]));
            }
            set {
                this["CMLContext"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("null")]
        public string CMLDefaultAnnotator {
            get {
                return ((string)(this["CMLDefaultAnnotator"]));
            }
            set {
                this["CMLDefaultAnnotator"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("null")]
        public string CMLDefaultScheme {
            get {
                return ((string)(this["CMLDefaultScheme"]));
            }
            set {
                this["CMLDefaultScheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("null")]
        public string CMLDefaultRole {
            get {
                return ((string)(this["CMLDefaultRole"]));
            }
            set {
                this["CMLDefaultRole"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CMLSetConf {
            get {
                return ((bool)(this["CMLSetConf"]));
            }
            set {
                this["CMLSetConf"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CMLRemove {
            get {
                return ((bool)(this["CMLRemove"]));
            }
            set {
                this["CMLRemove"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CMLFill {
            get {
                return ((bool)(this["CMLFill"]));
            }
            set {
                this["CMLFill"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CheckUpdateOnStart {
            get {
                return ((bool)(this["CheckUpdateOnStart"]));
            }
            set {
                this["CheckUpdateOnStart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("null")]
        public string CMLDefaultStream {
            get {
                return ((string)(this["CMLDefaultStream"]));
            }
            set {
                this["CMLDefaultStream"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double CMLDefaultConf {
            get {
                return ((double)(this["CMLDefaultConf"]));
            }
            set {
                this["CMLDefaultConf"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.5")]
        public double CMLDefaultGap {
            get {
                return ((double)(this["CMLDefaultGap"]));
            }
            set {
                this["CMLDefaultGap"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.15")]
        public double CMLDefaultMinDur {
            get {
                return ((double)(this["CMLDefaultMinDur"]));
            }
            set {
                this["CMLDefaultMinDur"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DatabaseAskBeforeOverwrite {
            get {
                return ((bool)(this["DatabaseAskBeforeOverwrite"]));
            }
            set {
                this["DatabaseAskBeforeOverwrite"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1979-01-01")]
        public global::System.DateTime LastUpdateCheckDate {
            get {
                return ((global::System.DateTime)(this["LastUpdateCheckDate"]));
            }
            set {
                this["LastUpdateCheckDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int ContinuousHotkeysNumber {
            get {
                return ((int)(this["ContinuousHotkeysNumber"]));
            }
            set {
                this["ContinuousHotkeysNumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool LiveModeActivateMouse {
            get {
                return ((bool)(this["LiveModeActivateMouse"]));
            }
            set {
                this["LiveModeActivateMouse"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LOW;MEDIUM;HIGH")]
        public string ConvertToDiscreteClasses {
            get {
                return ((string)(this["ConvertToDiscreteClasses"]));
            }
            set {
                this["ConvertToDiscreteClasses"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.33;0.66;1.0")]
        public string ConvertToDiscreteThreshs {
            get {
                return ((string)(this["ConvertToDiscreteThreshs"]));
            }
            set {
                this["ConvertToDiscreteThreshs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.0")]
        public string ConvertToDiscreteDelays {
            get {
                return ((string)(this["ConvertToDiscreteDelays"]));
            }
            set {
                this["ConvertToDiscreteDelays"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("null")]
        public string CMLDefaultTrainer {
            get {
                return ((string)(this["CMLDefaultTrainer"]));
            }
            set {
                this["CMLDefaultTrainer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CMLDirectory {
            get {
                return ((string)(this["CMLDirectory"]));
            }
            set {
                this["CMLDirectory"] = value;
            }
        }
    }
}
