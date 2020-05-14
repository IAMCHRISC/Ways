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
    /// Logique d'interaction pour AdminHomPage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private void NavigateToAddQuestionPage(object sender, RoutedEventArgs e)
        {
            adminMainFrame.Visibility = Visibility.Visible;
            adminMainFrame.Content = new AddQuestionPage();
        }

        private void NavigateToEditQuestionPage(object sender, RoutedEventArgs e)
        {
            adminMainFrame.Visibility = Visibility.Visible;
            adminMainFrame.Content = new EditQuestionPage();
        }

        private void NavigateToDeleteQuestionPage(object sender, RoutedEventArgs e)
        {
            adminMainFrame.Visibility = Visibility.Visible;
            adminMainFrame.Content = new DeleteQuestionPage();
        }

        private void NavigateToEmailParamPage(object sender, RoutedEventArgs e)
        {
            adminMainFrame.Visibility = Visibility.Visible;
            adminMainFrame.Content = new EmailParamPage();
        }

        private void NavigateToEditGameLadderPage(object sender, RoutedEventArgs e)
        {
            adminMainFrame.Visibility = Visibility.Visible;
            adminMainFrame.Content = new EditGameLadderPage();
        }
    }
}
