using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Sourse
{
    internal class StartAddData
    {
        public async void AddFullParametr()
        {
            AddLevel();
            AddMana();
            AddHealf();
            AddArmor();
        }
        private async void AddLevel()
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Levels.Any())
                {
                    db.Levels.AddRange(new List<Level>
                     {
                         new Level { LevelName = "Лёгкий" },
                         new Level { LevelName = "Средний" },
                         new Level { LevelName = "Сложный" }
                     });
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные с уроней успешно записались");
                }
                else
                {
                    MessageBox.Show("Данные с уроней не записались в базу данных или уже добавлена");
                }
            }
        }
        private async void AddMana()
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Manas.Any())
                {
                    db.Manas.AddRange(new List<Mana>
                    {
                        new Mana { ValueMana = 50},
                         new Mana { ValueMana = 75},
                        new Mana { ValueMana = 100}
                    });
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные успешно запипсались с Маной");
                }
                else
                {
                    MessageBox.Show("Данные с Маной не записались в базу данных или уже добавлена");
                }
            }
        }
        private async void AddArmor()
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Armors.Any())
                {
                    db.Armors.AddRange(new List<Armor>
                    {
                        new Armor { ValueArmor = 25},
                        new Armor { ValueArmor = 50},
                        new Armor { ValueArmor = 75}
                        
                    });
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные успешно запипсались с Армором");
                }
                else
                {
                    MessageBox.Show("Данные с Армором не записались в базу данных или уже добавлена");
                }
            }
        }
        private async void AddHealf()
        {
            using (var db = new ApplicationContext())
            {
                if (!db.Healfs.Any())
                {
                    db.Healfs.AddRange(new List<Healf>
                    {                        
                        new Healf { ValueHealf = 25},
                        new Healf { ValueHealf = 50},
                        new Healf { ValueHealf = 75}
                    });
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные успешно запипсались с ХП");
                }
                else
                {
                    MessageBox.Show("Данные с ХП не записались в базу данных или уже добавлена");
                }
            }
        }
    }
}
