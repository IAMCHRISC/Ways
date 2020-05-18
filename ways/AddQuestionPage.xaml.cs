using ADO;
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
    /// Logique d'interaction pour AddQuestionPage.xaml
    /// </summary>
    public partial class AddQuestionPage : Page
    {
        public AddQuestionPage()
        {
            InitializeComponent();
            // récupérer les types de question
            typesComboBox.ItemsSource = QuestionType.GetQuestionTypes();
            firstLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
            secondLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
            thirdLinkedJobsComboBox.ItemsSource = Jobs.GetJobs();
        }
    }
}
