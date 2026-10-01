namespace Scope_India.Models
{
    public class CourseDetails
    {
        public int? CourseId { get; set; }

        public string CourseName { get; set; }=string.Empty;

        public string CourseDuration { get; set; }= string.Empty;

        public int CourseFee { get; set; }
    }
}
