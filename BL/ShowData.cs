using System;
using System.Collections.Generic;

namespace Ask.BL
{
    /// <summary>
    /// Class for Showing Questions in the 
    /// </summary>
    class ShuffleData
    {
        /// <summary>
        /// shuffles the question list specified
        /// </summary>
        /// <param name="QuestionList"> list of question returned from the database </param>
        /// <returns> a question list to be shown in the MainPage </returns>
        public List<BL.Question> ShuffleQuestions(List<BL.Question> QuestionList)
        {
            Random randomize = new Random();
            List<BL.Question> ShuffledQuestionList = new List<BL.Question>();

            while(QuestionList.Count != 0)
            {
                int randomElement = randomize.Next(QuestionList.Count);
                ShuffledQuestionList.Add(QuestionList[randomElement]);
                QuestionList.Remove(QuestionList[randomElement]);
            }
            return ShuffledQuestionList;
        }
    }
}