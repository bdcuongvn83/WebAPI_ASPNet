using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebAPIPortal.Models
{
    [Table("STUDENT")]
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return FirstMidName + "_" + LastName; }
        }

        
    }
}
