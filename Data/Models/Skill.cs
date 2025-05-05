using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectCursovay.Data.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string? ValueMana { get; set; }
    }
}
