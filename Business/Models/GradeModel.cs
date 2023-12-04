using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class GradeModel
    {
        public int GradeId { get; set; }

        [Required]
        [MaxLength(11)]
        public string Year { get; set; }
    }
}
