----------------------------------------------------------------
-- Insert Questions
Create proc InsertQuestions
@Question varchar(3000),
@Answer varchar(3000),
@Kind varchar(100),
@Levels int
as
Insert Into QuestionsTable(Question, Answer, Kind, Levels)
values (@Question, @Answer, @Kind, @Levels)
