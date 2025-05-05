using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectCursovay.Data.Models
{
    public class PlayerDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }          // Было NamePlayer
        public string LevelName { get; set; }
        public int HealthValue { get; set; }      // Было ValueHealf
        public int ManaValue { get; set; }        // Было ValueMana
        public int ArmorValue { get; set; }       // Было ValueArmor
    }
}
