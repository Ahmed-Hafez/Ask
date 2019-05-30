using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ask.BL
{
    public class Question
    {
        private int questionNumber; // question number in the database
        private string question;    // The question which will be ask for the user
        private string answer;      // The correct answer of the question
        private string kind;        // Kind of the question
        private int level;          // level of difficulty for the question
        

        /// <summary>
        /// non intializing constructor
        /// </summary>
        public Question() { }
        
        /// <summary>
        /// Intialize a new instance from Question class
        /// </summary>
        public Question(string question, string answer, string kind, int level)
        {
            this.question = question;
            this.answer = answer;
            this.kind = kind;
            this.level = level;
        }


        /// <summary>
        /// Intialize a new instance from Question class
        /// </summary>
        public Question(int questionNumber, string question, string answer, string kind, int level)
        {
            this.questionNumber = questionNumber;
            this.question = question;
            this.answer = answer;
            this.kind = kind;
            this.level = level;
        }
        
        public string GetQuestion() { return question; }

        public string GetAnswer() { return answer; }

        /// <summary>
        /// Insert Question on the DataBase
        /// </summary>
        public void InsertData()
        {
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter(@"Question", SqlDbType.VarChar, 3000);
            param[0].Value = this.question;

            param[1] = new SqlParameter(@"Answer", SqlDbType.VarChar, 3000);
            param[1].Value = this.answer;

            param[2] = new SqlParameter(@"Kind", SqlDbType.VarChar, 100);
            param[2].Value = this.kind;

            param[3] = new SqlParameter(@"Levels", SqlDbType.Int);
            param[3].Value = this.level;
            
            data.executeCommand("InsertQuestions", param);
        }
        
        /// <summary>
        /// Delete Question from the DataBase
        /// </summary>
        /// <param name="QuestionNumber"> the primary key of the selected question </param>
        public void DeletedQuestion(int QuestionNumber)
        {
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter(@"Question_Number", SqlDbType.Int);
            param[0].Value = QuestionNumber;
            
            data.executeCommand("DeleteQuestions", param);
        }

        /// <summary>
        /// Delete All Questions from the DataBase
        /// </summary>
        public void DeletedAllQuestions()
        {
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            data.executeCommand("DeleteAllQuestions", null);
        }
        
        /// <summary>
        /// select some questions from the database depending on its level and kind
        /// </summary>
        /// <param name="level"> paramter used to get data from the database </param>
        /// <param name="kind"> paramter used to get data from the database </param>
        /// <param name="numberOfQuestions"> number of questions with the used constraints(level,kind) in the database </param>
        /// <returns> list of the selected question in the database </returns>
        public List<Question> getSomeQuestionWithKind(int level, string kind, out int numberOfQuestions)
        {
            List<Question> QuestionList;
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter(@"Levels", SqlDbType.Int);
            param[0].Value = level;

            param[1] = new SqlParameter(@"Kind", SqlDbType.VarChar, 100);
            param[1].Value = kind;
            
            DataTable dataTable = data.selectData("getQuestionsWithKinds", param);

            DataTableReader tableReader = new DataTableReader(dataTable);
            Question Question_Data;

            if (tableReader.HasRows)
            {
                numberOfQuestions = 0;
                QuestionList = new List<Question>();
                while (tableReader.Read())
                {
                    Question_Data = new Question
                    (
                      (int)tableReader.GetValue(0)      // Question_Number  
                    , tableReader.GetString(1)          // Question 
                    , tableReader.GetString(2)          // Answer
                    , tableReader.GetString(3)          // Kind
                    , (int)tableReader.GetValue(4)      // Level
                    );
                    QuestionList.Add(Question_Data);
                    numberOfQuestions++;
                }
                return QuestionList;
            }
            else
            {
                numberOfQuestions = 0;
                return null;
            }
        }

        /// <summary>
        /// select some questions from the database depending on its level
        /// </summary>
        /// <param name="level"> paramter used to get data from the database </param>
        /// <param name="numberOfQuestions">number of questions with the used constraints(level,kind) in the database </param>
        /// <returns> list of the selected question in the database </returns>
        public List<Question> getSomeQuestionWithoutKind(int level, out int numberOfQuestions)
        {
            List<Question> QuestionList;
            DAL.DataAccessLayer data = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter(@"Levels", SqlDbType.Int);
            param[0].Value = level;
            
            DataTable dataTable = data.selectData("getQuestionsWithoutKinds", param);

            DataTableReader tableReader = new DataTableReader(dataTable);
            Question Question_Data;

            if (tableReader.HasRows)
            {
                numberOfQuestions = 0;
                QuestionList = new List<Question>();
                while (tableReader.Read())
                {
                    Question_Data = new Question
                    (
                      (int)tableReader.GetValue(0)      // Question_Number  
                    , tableReader.GetString(1)          // Question 
                    , tableReader.GetString(2)          // Answer
                    , tableReader.GetString(3)          // Kind
                    , (int)tableReader.GetValue(4)      // Level
                    );
                    QuestionList.Add(Question_Data);
                    numberOfQuestions++;
                }
                return QuestionList;
            }
            else
            {
                numberOfQuestions = 0;
                return null;
            }
        }
    }
}