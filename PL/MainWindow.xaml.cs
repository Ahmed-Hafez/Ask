using System;
using System.Windows;
using System.Windows.Input;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Pages
        /// <summary>
        /// declared to navigate from\into them
        /// </summary>
        private DeletePage deletePage;
        private SelectPage selectPage;
        private NewGamePage newGamePage;
        #endregion
        
        public MainWindow()
        {
            InitializeComponent();
            selectPage = new SelectPage();
            newGamePage = new NewGamePage();
            Pages.Content = newGamePage;

        }

        #region titleBar
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to exit ?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        #endregion

        #region Menu Strip

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Pages.Content = newGamePage;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (Pages.Content == deletePage)
            {
                InsertQuestionWindow insertQuestionWindow = new InsertQuestionWindow();
                insertQuestionWindow.ShowDialog();
                deletePage.FillDataGrid(); // reintialize the Grid View
            }
            else if (Pages.Content == selectPage)
            {
                InsertQuestionWindow insertQuestionWindow = new InsertQuestionWindow();
                insertQuestionWindow.ShowDialog();
                selectPage.InitializeComBoxes(); // reintialize the combo boxes
            }
            else if (Pages.Content == newGamePage) 
            {
                InsertQuestionWindow insertQuestionWindow = new InsertQuestionWindow();
                insertQuestionWindow.ShowDialog();
            }
            else
            {
                /*  if all condtions returned false this means that 
                 *  the user was in the (DeletePage) and Clicked the (StartBtn)
                 *  so the current page will not the same page which was declared in line 16
                 *  Cuz the declaration of the DeletePage of this class is in line 92
                 */

                InsertQuestionWindow insertQuestionWindow = new InsertQuestionWindow();
                insertQuestionWindow.ShowDialog();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            deletePage = new DeletePage();
            Pages.Content = deletePage;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutPage_Video aboutPage_Video = new AboutPage_Video();
            Pages.Content = aboutPage_Video;
        }

        #endregion
    }
}