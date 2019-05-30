using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace Ask.PL
{
    /// <summary>
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        private string[] levels;                 // used to intialize the (LevelComboBox)
        private int numberOfQuestionsRequired;   // the number of questions which the user select
        private int numberOfQuestionsInDatabase; // the total number of questions in tne database

        /// <summary>
        /// the question list which returned from the database
        /// 
        /// each item contains Tuple which items declared as
        /// 
        /// item1 : Question_Number
        /// item2 : Question
        /// item3 : Answer
        /// item4 : Kind
        /// item5 : Level
        /// </summary>
        private List<BL.Question> QuestionList; 

        public SelectPage()
        {
            InitializeComponent();
            InitializeComBoxes();
        }

        /// <summary>
        /// intializing combo boxes data
        /// </summary>
        public void InitializeComBoxes()
        {
            // filling the LevelComboBox
            levels = new string[5] { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5" };
            LevelComboBox.ItemsSource = levels;
            LevelComboBox.SelectedItem = levels[0];

            // filling the KindComboBox
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            DataTable dataTable = new DataTable();
            dataTable = data.selectData("getKinds", null);
            DataTableReader tableReader = new DataTableReader(dataTable);
            if (tableReader.HasRows)
            {
                HashSet<string> kinds = new HashSet<string>();
                while (tableReader.Read())
                {
                    kinds.Add(tableReader.GetString(0));
                }
                KindComboBox.ItemsSource = kinds;
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            int LevelSelectedItem = 1; // Default value for the (LevelComboBox)

            if (LevelComboBox.SelectedItem.Equals("Level 1"))
            {
                LevelSelectedItem = 1;
            }
            else if (LevelComboBox.SelectedItem.Equals("Level 2"))
            {
                LevelSelectedItem = 2;
            }
            else if (LevelComboBox.SelectedItem.Equals("Level 3"))
            {
                LevelSelectedItem = 3;
            }
            else if (LevelComboBox.SelectedItem.Equals("Level 4"))
            {
                LevelSelectedItem = 4;
            }
            else if (LevelComboBox.SelectedItem.Equals("Level 5"))
            {
                LevelSelectedItem = 5;
            }
            if (numberOfQuestionsTxt.Text == "")
            {
                MessageBox.Show("Number of Questions is Required", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                // make sure from the number of Questions 
                // it should be more than 0 and less than or equal 
                // the number of questions (with inserted data) in the database
                // Note : make sure from the second condition in line 109 and line 124
                try
                {
                    int temp = Convert.ToInt32(numberOfQuestionsTxt.Text);
                    if (temp <= 0)
                    {
                        MessageBox.Show("Invalid number of questions", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        numberOfQuestionsRequired = temp;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid number of questions", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                if (KindComboBox.SelectedItem == null)
                {
                    BL.Question question = new BL.Question();
                    QuestionList = new List<BL.Question>();
                    QuestionList = question.getSomeQuestionWithoutKind(LevelSelectedItem, out numberOfQuestionsInDatabase);
                    if (numberOfQuestionsInDatabase < numberOfQuestionsRequired) // make sure from the second condition (see line 83)
                    {
                        MessageBox.Show("There is Know enough question","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    else
                    {
                        MainPage mainPage = new MainPage(QuestionList, numberOfQuestionsRequired);
                        this.NavigationService.Navigate(mainPage);
                    }
                }
                else
                {
                    BL.Question question = new BL.Question();
                    QuestionList = new List<BL.Question>();
                    QuestionList = question.getSomeQuestionWithKind(LevelSelectedItem, (string)KindComboBox.SelectedItem, out numberOfQuestionsInDatabase);
                    if (numberOfQuestionsInDatabase < numberOfQuestionsRequired) // make sure from the second condition (see line 83)
                    {
                        MessageBox.Show("There is no enough question", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MainPage mainPage = new MainPage(QuestionList, numberOfQuestionsRequired);
                        this.NavigationService.Navigate(mainPage); // go to MainPage
                    }
                }

            }
        }
    }
}