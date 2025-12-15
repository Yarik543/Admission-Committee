namespace AdmissionCommittee.Models
{
    public class Applicant
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string EduForm { get; set; }
        public int MathScore { get; set; }
        public int RusScore { get; set; }
        public int ITScore { get; set; }
    }
}