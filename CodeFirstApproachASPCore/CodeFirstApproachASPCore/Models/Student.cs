using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproachASPCore.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("StudentGender",TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }

        //[Column("RollNo", TypeName = "int")]
        [Required]
        public int RollNo { get; set; }

        //[Column("Standard", TypeName = "varchar(20)")]
        [Required]
        public string Standard { get; set; }
    }
}
