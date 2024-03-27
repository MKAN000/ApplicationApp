using System.ComponentModel.DataAnnotations;

namespace ApplicationAppApi.Models.ApplicantModel
{
    public class ApplicantModel
    {
        [Key]
        public int ID { get; set; }
        public int AlbumNumber { get; set; }
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subdivision { get; set; }
        public string FacultyGroup { get; set; }
    }
}
