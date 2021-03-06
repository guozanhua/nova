﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ssi
{
    /// <summary>
    /// Interaction logic for DatabaseAnnotatorWindow.xaml
    /// </summary>
    /// 

    public partial class DatabaseAdminAnnotatorWindow : Window
    {
        DatabaseAnnotator annotator;

        public DatabaseAdminAnnotatorWindow(ref DatabaseAnnotator annotator, List<string> names = null)
        {
            InitializeComponent();

            this.annotator = annotator;

            if (names == null)
            {
                NameBox.Items.Add(annotator.Name);
                NameBox.SelectedIndex = 0;
                NameBox.IsEnabled = false;
                FullNameField.Text = annotator.FullName;
                EmailField.Text = annotator.Email;
                ExpertiseBox.SelectedIndex = annotator.Expertise;
                foreach (var item in RoleBox.Items)
                {
                    if (item.ToString().Contains(annotator.Role))
                    {
                        RoleBox.SelectedItem = item;
                    }
                }
            }
            else
            {
                NameBox.ItemsSource = names;
            }
        } 

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            annotator.Name = (string)NameBox.SelectedItem;
            annotator.FullName = FullNameField.Text;
            annotator.Email = EmailField.Text;
            annotator.Role = RoleBox.SelectionBoxItem.ToString();
            annotator.Expertise = ExpertiseBox.SelectedIndex;

            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}

