
public class Assessment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsMandatory { get; set; }
    public ICollection<Question> Questions { get; set; }
}