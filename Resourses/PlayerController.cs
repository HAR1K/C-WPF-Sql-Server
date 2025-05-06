using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D.Converters;
using Microsoft.EntityFrameworkCore;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Sourse
{
    internal class PlayerController
    {
        public async Task<int> SavePlayerAsync(string playerName, int armorId, int manaId, int healfId, int levelId)
        {
            using (var db = new ApplicationContext())
            {
                // ... аналогичная проверка для Level
                var levelExists = await db.Levels.AnyAsync(l => l.Id == levelId);
                if (!levelExists) throw new ArgumentException("Level does not exist.");

                var player = new Player
                {
                    NamePlayer = playerName,
                    ArmorId = armorId,
                    ManaId = manaId,
                    HealfId = healfId,
                    LevelId = levelId
                };

                db.Players.Add(player);
                await db.SaveChangesAsync();
                return player.Id;
            }
        }
        public async Task DeletePlayerDirectlyAsync(int playerId)
        {
            using (var db = new ApplicationContext())
            {
                var player = new Player { Id = playerId }; // Создаем объект только с Id
                db.Players.Attach(player); // Добавляем в контекст
                db.Players.Remove(player); // Помечаем на удаление
                await db.SaveChangesAsync();
            }
        }
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            using (var db = new ApplicationContext())
            {
                return await db.Players
                    .Include(p => p.Armor)
                    .Include(p => p.Mana)
                    .Include(p => p.Healf)
                    .Include(p => p.Level)
                    .Select(p => new Player
                    {
                        Id = p.Id,
                        NamePlayer = p.NamePlayer,
                        ArmorId = p.Armor != null ? p.Armor.Id : 0,
                        Armor = p.Armor != null ? p.Armor : null,
                        Mana = p.Mana != null ? p.Mana : null,
                        ManaId = p.Mana != null ? p.Mana.Id : 0,
                        Healf = p.Healf != null ? p.Healf: null,
                        HealfId = p.Healf != null ? p.Healf.Id : 0
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
        public async Task<bool> DeletePlayerSimpleAsync(int playerId)
        {
            using (var db = new ApplicationContext())
            {
                var player = await db.Players.FindAsync(playerId);
                if (player == null) return false;

                db.Players.Remove(player);
                return await db.SaveChangesAsync() > 0;
            }
        }
        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            using (var db = new ApplicationContext())
            {
             return await db.Players
                                .Include(p => p.Armor)
                                .Include(p => p.Mana)
                                .Include(p => p.Healf)
                                .FirstOrDefaultAsync(p => p.Id == id);
            }
        }
        public async void UpdatePlayer(int playerId, string newName, int? armorId, int? manaId, int? healfId, int? levelId)
        {
            using (var db = new ApplicationContext())
            {
                // Находим игрока по Id
                var player = db.Players.FirstOrDefault(p => p.Id == playerId);
                if (player == null)
                    throw new ArgumentException("Player not found.");

                // Проверяем существование уровня (если levelId указан)
                if (levelId.HasValue)
                {
                    var levelExists = db.Levels.Any(l => l.Id == levelId.Value);
                    if (!levelExists)
                        throw new ArgumentException("Level does not exist.");
                }

                // Обновляем только переданные поля
                if (!string.IsNullOrEmpty(newName))
                    player.NamePlayer = newName;

                if (armorId.HasValue)
                    player.ArmorId = armorId.Value;

                if (manaId.HasValue)
                    player.ManaId = manaId.Value;

                if (healfId.HasValue)
                    player.HealfId = healfId.Value;

                if (levelId.HasValue)
                    player.LevelId = levelId.Value;

               await  db.SaveChangesAsync();
            }
        }
    }
}
