using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectCursovay.Data.Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        public int ValueArmor { get; set; }
    }
}
