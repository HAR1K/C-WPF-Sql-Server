using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;
using MyProjectCursovay.Sourse;

namespace MyProjectCursovay.Desktop.Pages
{
    public partial class PagePlayerCreated : Page
    {
        private int manaValue;
        private int heaflValue;
        private int armorValue;
        ApplicationContext db;
        InitializingClass initializing;
        public PagePlayerCreated()
        {
            InitializeComponent();
            db = new ApplicationContext();
            initializing = new InitializingClass();
            initializing.interfaseSettings.ComboBoxLevelSistem(comboBox);
            initializing.startAddData.AddFullParametr();
        }
        // Created_Click
        private void Created_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var idLevel = comboBox.SelectedIndex;
                initializing.playerController.SavePlayerAsync(namePerson.Text, idLevel, idLevel, idLevel, idLevel);
                MessageBox.Show("Урааааа бессонные ночи убитый режим сохронение какйфуеммм");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        //CheckLeveling_Click
        private void CheckLeveling_Click(object sender, RoutedEventArgs e)
        {
            var сurrentLevel = comboBox.Text;
            var idLevel = comboBox.SelectedIndex;
            var healfList = initializing.getData.GetAllHealf();
            var manaList = initializing.getData.GetAllMana();
            var armorList = initializing.getData.GetAllArmor();
            if (сurrentLevel == "Лёгкий")
            {
                textBlock.Text = $"{idLevel}";
                mana.Value = manaList[idLevel].ValueMana;
                healf.Value = healfList[idLevel].ValueHealf;
                armor.Value = armorList[idLevel].ValueArmor;
            }
            if (сurrentLevel == "Средний")
            {
                textBlock.Text = $"{idLevel}";
                mana.Value = manaList[idLevel].ValueMana;
                healf.Value = healfList[idLevel].ValueHealf;
                armor.Value = armorList[idLevel].ValueArmor;
            }
            if (сurrentLevel == "Сложный")
            {
                textBlock.Text = $"{idLevel}";
                mana.Value = manaList[idLevel].ValueMana;
                healf.Value = healfList[idLevel].ValueHealf;
                armor.Value = armorList[idLevel].ValueArmor;
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                var idLevel = comboBox.SelectedIndex;
                initializing.playerController.DeletePlayerDirectlyAsync(idLevel);
                MessageBox.Show("Удаление удачно сработало");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
