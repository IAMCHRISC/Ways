﻿using ADO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ways
{
    /// <summary>
    /// Logique d'interaction pour OrientationResultsPage.xaml
    /// </summary>
    public partial class OrientationResultsPage : Window
    {
        private List<Jobs> jobsList;

        public List<Jobs> JobsList { get => jobsList; set => jobsList = value; }

        public OrientationResultsPage(List<int> results)
        {
            InitializeComponent();
            JobsList = new List<Jobs>
            {
                Jobs.GetJobById(results[0]),
                Jobs.GetJobById(results[1]),
                Jobs.GetJobById(results[2]),
            };
            mainJobTitleLabel.Text = JobsList[0].Title;
            mainJobDescLabel.Text = JobsList[0].Description;
            secondJobTitleLabel.Content = "- " + JobsList[1].Title;
            thirdJobTitleLabel.Content = "- " + JobsList[2].Title;
        }

        private void SendByEmail(object sender, RoutedEventArgs e)
        {
            // Open a new window to send results by email
            OrientationEmailPage orientationEmailPage = new OrientationEmailPage(JobsList);
            orientationEmailPage.Show();
            this.Close();
        }

        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            // Get back to home page
            this.Close();
        }
    }
}
