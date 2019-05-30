----------------------------------------------------------------
-- Get Questions Without its Kinds
Create proc getQuestionsWithoutKinds
@Levels int
as
select * from QuestionsTable 
where Levels=@Levels