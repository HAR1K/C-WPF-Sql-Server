using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Sourse
{
    internal class ProgressBarSettings
    {
        public void SetManaToProgressBar(int manaId, ProgressBar progressBar)
        {
            using (var db = new ApplicationContext())
            {
                var mana = db.Manas.FirstOrDefault(m => m.Id == manaId);

                if (mana != null)
                {
                    // Устанавливаем максимальное значение (если нужно)
                    progressBar.Maximum = 100; // или другое нужное значение
                    // Устанавливаем текущее значение
                    progressBar.Value = mana.ValueMana;
                }
                else
                {
                    MessageBox.Show("Объект Mana с таким ID не найден.");
                }
            }
        }
        public void SetHealfToProgressBar(int healfId, ProgressBar progressBar)
        {
            using (var db = new ApplicationContext())
            {
                var healf = db.Healfs.FirstOrDefault(h => h.Id == healfId);

                if (healf != null)
                {
                    // Устанавливаем максимальное значение (если нужно)
                    progressBar.Maximum = 100; // или другое нужное значение
                    // Устанавливаем текущее значение
                    progressBar.Value = healf.ValueHealf;
                }
                else
                {
                    MessageBox.Show("Объект Healf с таким ID не найден.");
                }
            }
        }
        public void SetArmorToProgressBar(int armorId, ProgressBar progressBar)
        {
            using (var db = new ApplicationContext())
            {
                var armor = db.Armors.FirstOrDefault(m => m.Id == armorId);

                if (armor != null)
                {
                    // Устанавливаем максимальное значение (если нужно)
                    progressBar.Maximum = 100; // или другое нужное значение
                    // Устанавливаем текущее значение
                    progressBar.Value = armor.ValueArmor;
                }
                else
                {
                    MessageBox.Show("Объект Mana с таким ID не найден.");
                }
            }
        }
        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            using (var db = new ApplicationContext())
            {
                return await db.Players
                    .Where(p => p.Id == id)
                    .Include(p => p.Armor)
                    .Include(p => p.Mana)
                    .Include(p => p.Healf)
                    .Include(p => p.Level)
                    .Select(p => new Player
                    {
                        Id = p.Id,
                        NamePlayer = p.NamePlayer,
                        ArmorId = p.Armor != null ? p.Armor.Id : 0,
                        ManaId = p.Mana != null ? p.Mana.Id : 0,
                        HealfId = p.Healf != null ? p.Healf.Id : 0,
                        LevelId = p.Level != null ? p.Mana.Id : 0,
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
        }
    }
}
