namespace TaskManagement1.Models
{
    public class AssignTaskModel
    {
        public int Id { get; set; }
        public int Taskid { get; set; }
        public int UserId { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? Remark { get; set; }
        
    }
}
