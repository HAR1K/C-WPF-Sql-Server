using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Sourse
{
    internal class GetData
    {
        public List<Mana> GetAllMana()
        {
            using (var db = new ApplicationContext())
            {
                return db.Manas.ToList();
            }
        }
        public List<Armor> GetAllArmor()
        {
            using (var db = new ApplicationContext())
            {
                return db.Armors.ToList();
            }
        }
        public List<Healf> GetAllHealf()
        {
            using (var db = new ApplicationContext())
            {
                return db.Healfs.ToList();
            }
        }
        public List<Level> GetAllLevel()
        {
            using (var db = new ApplicationContext())
            {
                return db.Levels.ToList();
            }
        }
    }
}
