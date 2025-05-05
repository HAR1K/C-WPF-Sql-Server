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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Page
    {
        private readonly int _playerId;

        public EditPlayerWindow(int playerId)
        {
            InitializeComponent();
            _playerId = playerId;
            LoadPlayerData();
        }

        private void LoadPlayerData()
        {
            using (var context = new ApplicationContext())
            {
                var player = context.Players
                    .Include(p=>p.Level)
                    .Include(p => p.Healf)
                    .Include(p => p.Mana)
                    .Include(p => p.Armor)
                    .First(p => p.Id == _playerId);

                // Загрузка данных
                NameBox.Text = player.NamePlayer;
                LevelCombo.ItemsSource = context.Levels.ToList();
                LevelCombo.SelectedValue = player.Level.Id;
                HealthBox.Text = player.Healf.ValueHealf.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var player = context.Players
                    .Include(p => p.Level)
                    .Include(p => p.Healf)
                    .Include(p => p.Mana)
                    .Include(p => p.Armor)
                    .First(p => p.Id == _playerId);

                // Обновление данных
                player.NamePlayer = NameBox.Text;
                player.LevelId = LevelCombo.SelectedIndex;
                player.Healf.ValueHealf = int.Parse(HealthBox.Text);

                context.SaveChanges();
            }
        }
    }
}
