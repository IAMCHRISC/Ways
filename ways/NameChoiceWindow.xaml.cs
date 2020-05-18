using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ways
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NameChoiceWindow : Window
    {
        private static int testChoice;

        public static int TestChoice { get => testChoice; set => testChoice = value; }

        public NameChoiceWindow(int choice)
        {
            InitializeComponent();
            TestChoice = choice;
        }

        // Check if the given name is not empty
        private bool CheckNameValidity()
        {
            bool isValid = false;
            if(textBox_Name.Text.Length > 0)
            {
                isValid = true;
            }
            return isValid;
        }

        public void NavigateToQuestions(object sender, RoutedEventArgs e)
        {
            if (CheckNameValidity()) {
                if(TestChoice == 1)
                {
                    OrientationQuestionWindow questionWindow = new OrientationQuestionWindow(textBox_Name.Text);
                    questionWindow.Show();
                    this.Close();
                }
                else if (TestChoice == 2)
                {
                    Game game = new Game(textBox_Name.Text);
                    game.Show();
                    this.Close();
                }
            }
            else
            {
                validityLabel.Content = "Veuillez saisir un nom de joueur.";
            }
        }
    }
}
