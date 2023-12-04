using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }

        [Required]
        [MaxLength(11)]
        public string Year { get; set; }

        // Navigation property for the Students relationship
        public ICollection<Student> Students { get; set; }
    }
}
