----------------------------------------------------------------
-- Get Questions With its Kinds
Create proc getQuestionsWithKinds
@Levels int,
@Kind varchar(100)
as
select * from QuestionsTable 
where Levels=@Levels and Kind=@Kind