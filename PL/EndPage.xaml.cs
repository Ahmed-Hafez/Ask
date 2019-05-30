using System.Windows;
using System.Windows.Controls;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        /// <summary>
        /// the page in which the result will be shown
        /// </summary>
        /// <param name="score"> the score of the user </param>
        /// <param name="totalScore"> the total score (represents the number of question) </param>
        public EndPage(int score,int totalScore)
        {
            InitializeComponent();

            string[] param = new string[] 
            {
                score.ToString(),
                totalScore.ToString()
            }; 
            scoreLabel.Content = string.Format("{0} / {1}", param);
        }

        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            // go to SelectPage
            SelectPage selectPage = new SelectPage();
            this.NavigationService.Navigate(selectPage);
        }
    }
}