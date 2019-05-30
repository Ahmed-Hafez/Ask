using System.Windows;
using System.Windows.Input;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for InsertQuestionWindow.xaml
    /// </summary>
    public partial class InsertQuestionWindow : Window
    {
        private string[] levels; // used to intialize the (LevelComboBox)

        public InsertQuestionWindow()
        {
            InitializeComponent();

            //intialize the (LevelComboBox)
            levels = new string[5] { "Level 1" , "Level 2", "Level 3", "Level 4", "Level 5" };
            LevelComboBox.ItemsSource = levels;
            LevelComboBox.SelectedItem = levels[0];
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            int QuestionLevel = 1; // Default Value for the (LevelComboBox)

            // Make sure that all fields was filled 
            if (QuestionTxt.Text == "")
            {
                MessageBox.Show("Question text is required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (AnswerTxt.Text == "")
            {
                MessageBox.Show("Answer text is required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (KindTxt.Text == "")
            {
                MessageBox.Show("Kind text is required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (LevelComboBox.SelectedItem.Equals(levels[0]))
                {
                    QuestionLevel = 1;
                }
                else if (LevelComboBox.SelectedItem.Equals(levels[1]))
                {
                    QuestionLevel = 2;
                }
                else if (LevelComboBox.SelectedItem.Equals(levels[2]))
                {
                    QuestionLevel = 3;
                }
                else if (LevelComboBox.SelectedItem.Equals(levels[3]))
                {
                    QuestionLevel = 4;
                }
                else if (LevelComboBox.SelectedItem.Equals(levels[4]))
                {
                    QuestionLevel = 5;
                }

                // adding the question to the database
                BL.Question question = new BL.Question(QuestionTxt.Text, AnswerTxt.Text, KindTxt.Text, QuestionLevel);
                question.InsertData();
                MessageBox.Show("Question was added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                QuestionTxt.Text = "";
                AnswerTxt.Text = "";
                KindTxt.Text = "";
                LevelComboBox.SelectedIndex = 0;
            }
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}