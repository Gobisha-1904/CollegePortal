namespace CollegeERPPortal.Domain.Entities
{
   public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Course { get; set; }
    public DateTime DOB { get; set; } // ✅ Must exist
}

}
