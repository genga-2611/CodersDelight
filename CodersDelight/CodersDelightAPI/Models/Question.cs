public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
    public int AssessmentId { get; set; }
    public Assessment Assessment { get; set; }
}