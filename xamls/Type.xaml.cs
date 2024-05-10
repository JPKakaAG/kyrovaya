using kyrovaya.models;
using Microsoft.EntityFrameworkCore;
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

namespace kyrovaya.xamls
{
    /// <summary>
    /// Логика взаимодействия для Type.xaml
    /// </summary>
    public partial class Type : Window
    {
        public Type()
        {
            InitializeComponent();
        }

        void LoadDBInDataGrid()
        {
            using (KyrsovayaContext _db = new KyrsovayaContext())
            {
                int SelectedIndex = dg1.SelectedIndex;
                _db.ТипыКомплектующегоs.Load();
                dg1.ItemsSource = _db.ТипыКомплектующегоs.ToList();
                if (SelectedIndex != -1)
                {
                    if (SelectedIndex == dg1.Items.Count) SelectedIndex--;
                    dg1.SelectedIndex = SelectedIndex;
                    dg1.ScrollIntoView(dg1.SelectedItem);
                }
                dg1.Focus();
            }
        }

        private void Type1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
        }

        private void btnCancel1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
