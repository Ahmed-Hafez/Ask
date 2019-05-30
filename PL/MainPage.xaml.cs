using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private List<BL.Question> listShown; // the list of questions which will be shown
        private int QuestionIndex; // represents the index of the question in the (listShown) List
        private int numberOfQuestionsRequired; // represents the number of questions which the user selected in (SelectPage)
        private int score = 0;     // represents the score which user get in the game (Result) , this will be shown in the (EndPage)

        /// <summary>
        /// Intialize Componnent
        /// </summary>
        /// <param name="QuestionList"> the returned questions from the database </param>
        /// <param name="numberOfQuestionsRequired"> the number of questions which the user select </param>
        public MainPage(List<BL.Question> QuestionList, int numberOfQuestionsRequired)
        {
            // Initialize Data
            listShown = new List<BL.Question>();
            this.numberOfQuestionsRequired = numberOfQuestionsRequired;
            BL.ShuffleData ShowList = new BL.ShuffleData();
            this.listShown = ShowList.ShuffleQuestions(QuestionList);
            QuestionIndex = 0;

            // Initialize Component
            InitializeComponent();
            WrongLabel.Visibility = Visibility.Hidden;
            CorrectLabel.Visibility = Visibility.Hidden;
            ShowQuestion();
        }

        /// <summary>
        /// show the question to the user
        /// </summary>
        private void ShowQuestion()
        {
            QuestionNumberLabel.Content = string.Format("Question {0}", QuestionIndex + 1);
            QuestionTextLabel.Content = string.Format("{0} ?", listShown[QuestionIndex].GetQuestion().ToString());
            UserAnswerTxt.Text = "";
            CorrectAnswerLabel.Content = "";
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            QuestionIndex++; // go to the next question

            if(QuestionIndex == numberOfQuestionsRequired)
            {
                EndPage endPage = new EndPage(score, numberOfQuestionsRequired);
                this.NavigationService.Navigate(endPage); // go to (endPage)
            }
            else
            {
                ConfirmBtn.Visibility = Visibility.Visible;
                ShowQuestion();
                UserAnswerTxt.IsEnabled = true;
                WrongLabel.Visibility = Visibility.Hidden;
                CorrectLabel.Visibility = Visibility.Hidden;
            }
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UserAnswerTxt.Text == "" || UserAnswerTxt.Text == null)
            {
                MessageBox.Show("Please Write your answer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ConfirmBtn.Visibility = Visibility.Hidden;
                if (UserAnswerTxt.Text.ToLower() == listShown[QuestionIndex].GetAnswer().ToString().ToLower())
                {
                    score++;
                    CorrectLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    WrongLabel.Visibility = Visibility.Visible;
                }
            }
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            UserAnswerTxt.IsEnabled = false;
            CorrectAnswerLabel.Content = string.Format("Correct Answer : {0}", listShown[QuestionIndex].GetAnswer().ToString());
            ConfirmBtn.Visibility = Visibility.Hidden;
        }
    }
}