using kyrovaya.models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Class1;

namespace kyrovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void LoadDBInDataGrid()
        {
            using (KyrsovayaContext _db = new KyrsovayaContext())
            {
                int SelectedIndex = dg1.SelectedIndex;
                _db.Комплектующиеs.Load();
                _db.Отгрузкиs.Load();
                _db.Приемкаs.Load();
                _db.Производителиs.Load();
                _db.Складs.Load();
                _db.ТипыКомплектующегоs.Load();
                dg1.ItemsSource = _db.Комплектующиеs.ToList();
                if (SelectedIndex != -1)
                {
                    if (SelectedIndex == dg1.Items.Count) SelectedIndex--;
                    dg1.SelectedIndex = SelectedIndex;
                    dg1.ScrollIntoView(dg1.SelectedItem);
                }
                dg1.Focus();
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Уэээээ");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.Комплектующие = null;
            AddEditKompl f = new AddEditKompl();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dg1.SelectedItem != null) 
            { 
                Data.Комплектующие = (Комплектующие)dg1 .SelectedItem;
                AddEditKompl f = new AddEditKompl();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}