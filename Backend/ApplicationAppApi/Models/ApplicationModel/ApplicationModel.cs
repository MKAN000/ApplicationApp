using System.ComponentModel.DataAnnotations;

namespace ApplicationAppApi.Models.ApplicationModel
{
    public class ApplicationModel
    {
        [Key]
        public int Id { get; set; }
        public string CsvData { get; set; }
    }
}
