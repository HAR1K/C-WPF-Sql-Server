using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;
using MyProjectCursovay.Desktop.Pages;
using MyProjectCursovay.Sourse;

namespace MyProjectCursovay.Desktop
{
    /// <summary>
    /// Логика взаимодействия для SearchPlayer.xaml
    /// </summary>
    public partial class SearchPlayer : Window
    {
        private string _searchText;
        private InitializingClass initializing;
        private ApplicationContext _db;
        public SearchPlayer()
        {
            InitializeComponent();
            initializing = new InitializingClass();
            PlayersList.Items.Clear();
            LoadPlayers();
        }

        public void LoadPlayers()
        {
            using (var context = new ApplicationContext())
            {
                var result = context.Players
            .Include(p=>p.Mana)      // Проверьте название навигационного свойства
            .Include(p => p.Level)     // (должно совпадать с моделью EF)
            .Include(p => p.Healf)     // Например: Healf → Health
            .Include(p => p.Armor)
            .Select(p => new PlayerDataDto
            {
                Id = p.Id,
                Name = p.NamePlayer,
                LevelName = p.Level.LevelName,   // Проверьте иерархию: Level → LevelName
                HealthValue = p.Healf.ValueHealf,  // Healf → Health
                ManaValue = p.Mana.ValueMana,
                ArmorValue = p.Armor.ValueArmor
            })
            .ToList();
                PlayersList.ItemsSource = result;
            }
        }
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is PlayerDataDto player)
            {
                // Запрос подтверждения
                var result = MessageBox.Show(
                    $"Вы точно хотите удалить игрока {player.Name}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    DeletePlayer(player.Id);
                }
            }
            else
            {
                MessageBox.Show("Выберите игрока для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void DeletePlayer(int playerId)
        {
            try
            {
                using (var context = new ApplicationContext())
                {
                    var playerToDelete = await context.Players
                        .FirstOrDefaultAsync(p => p.Id == playerId);

                    if (playerToDelete != null)
                    {
                        context.Players.Remove(playerToDelete);
                        await context.SaveChangesAsync();
                        LoadPlayers(); // Обновляем список после удаления
                        MessageBox.Show("Игрок успешно удалён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is PlayerDataDto player)
            {
                ContentFrames.Navigate(new EditPlayerWindow(player.Id));
            }
        }
        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            _searchText = SearchTxt.Text.Trim();

            using (var context = new ApplicationContext())
            {
                try
                {
                    // Генерируем сущность для дальнейщих взаимодействий 
                    IQueryable<Player> query = context.Players
                        .Include(p => p.Mana)
                        .Include(p => p.Level)
                        .Include(p => p.Healf)
                        .Include(p => p.Armor);

                    // Добавляем условие поиска если текст не пустой
                    if (!string.IsNullOrEmpty(_searchText))
                    {
                        query = query.Where(p => p.NamePlayer.Contains(_searchText));
                    }

                    // Выполняем запрос и преобразуем в DTO
                    var result = await query
                        .Select(p => new PlayerDataDto
                        {
                            Id = p.Id,
                            Name = p.NamePlayer,
                            LevelName = p.Level.LevelName,
                            HealthValue = p.Healf.ValueHealf,
                            ManaValue = p.Mana.ValueMana,
                            ArmorValue = p.Armor.ValueArmor
                        })
                        .ToListAsync();

                    // Обновляем список игроков
                    PlayersList.ItemsSource = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ContentFrames_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
