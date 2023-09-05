using System.ComponentModel.DataAnnotations;

namespace Employee_Dept_CRUD.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int Did { get; set; }
        [Required]
        public string Dname { get; set; }
    }
}
