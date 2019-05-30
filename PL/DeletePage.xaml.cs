using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Common;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        /// <summary>
        /// Initialize new instance from DeletePage class
        /// </summary>
        public DeletePage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        /// <summary>
        /// filling the Grid View
        /// </summary>
        public void FillDataGrid()
        {
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            
            DataTable dataTable = new DataTable();
            dataTable = data.selectData("getAllQuestions", null);

            DataTableReader tableReader = new DataTableReader(dataTable);
            tableReader.Read();

            QuestionDataGridView.ItemsSource = tableReader;
        }
        
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int QuestionNumber;
                DbDataRecord selectedRow = (DbDataRecord)QuestionDataGridView.SelectedItem; // get the values of the selected row
                QuestionNumber = Convert.ToInt16(selectedRow.GetValue(0));

                BL.Question deletedQuestion = new BL.Question();
                deletedQuestion.DeletedQuestion(QuestionNumber);

                FillDataGrid();
            }
            catch { return; }
        }

        private void DeleteAllBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.Question question = new BL.Question();
                question.DeletedAllQuestions();

                FillDataGrid();
            }
            catch { return; }
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectPage selectPage = new SelectPage();
            this.NavigationService.Navigate(selectPage);
        }
    }
}