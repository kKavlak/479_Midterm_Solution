using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        public int? Rank { get; set; }

        public decimal? CumulativeGPA { get; set; }

        public int GradeId { get; set; }
        public string GradeOutput { get; set; }

    }
}
