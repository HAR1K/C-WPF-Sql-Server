using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Data.Models;

namespace MyProjectCursovay.Sourse
{
    internal class InterfaseSettings
    {
        public void ComboBoxLevelSistem(ComboBox cmbx)
        {
            using (var db = new ApplicationContext())
            {
                var levels = db.Levels.ToList();
                cmbx.ItemsSource = levels;
                cmbx.DisplayMemberPath = "LevelName";
                cmbx.SelectedValuePath = "Id";
            }
        }
    }
}
