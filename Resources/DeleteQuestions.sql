----------------------------------------------------------------
-- Delete some questions
Create proc DeleteQuestions
@Question_Number int
as
Delete From QuestionsTable where Question_Number=@Question_Number
