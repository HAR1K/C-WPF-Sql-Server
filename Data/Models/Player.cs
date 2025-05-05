using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MyProjectCursovay.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? NamePlayer { get; set; }

        public int ArmorId { get; set; }
        public Armor? Armor { get; set; }

        public int ManaId { get; set; }
        public Mana? Mana { get; set; }

        public int HealfId { get; set; }
        public Healf? Healf { get; set; }

        public int LevelId { get; set; }
        public Level? Level { get; set; }
    }
}
