using System;
using System.Windows;
using System.Windows.Controls;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for NewGamePage.xaml
    /// </summary>
    public partial class NewGamePage : Page
    {
        public NewGamePage()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectPage selectPage = new SelectPage();
            this.NavigationService.Navigate(selectPage); // go to SelectPage
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertQuestionWindow insertQuestionWindow = new InsertQuestionWindow();
            insertQuestionWindow.ShowDialog(); // open InsertQuestionWindow
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeletePage deletePage = new DeletePage();
            this.NavigationService.Navigate(deletePage); // go to DeletePage
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void StartBtn_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}