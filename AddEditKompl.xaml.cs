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
    /// Interaction logic for AddEditKompl.xaml
    /// </summary>
    public partial class AddEditKompl : Window
    {
        public AddEditKompl()
        {
            InitializeComponent();
        }
        KyrsovayaContext _db = new KyrsovayaContext();
        Комплектующие _комплектующие;
        private void AddEditKompl1_Loaded(object sender, RoutedEventArgs e)
        {
            cbIDproiz.ItemsSource = _db.Производителиs.ToList();
            cbIDproiz.DisplayMemberPath = "Idпроизводителя";
            cbIDsklada.ItemsSource = _db.Складs.ToList();
            cbIDsklada.DisplayMemberPath = "Idсклада";
            cbTypeKompl.ItemsSource = _db.ТипыКомплектующегоs.ToList();
            cbTypeKompl.DisplayMemberPath = "IdтипаКомплектующего";
            if (Data.Комплектующие == null)
            {
                AddEditKompl1.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить";
                _комплектующие = new Комплектующие();
            }
            else
            {
                AddEditKompl1.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить";
                _комплектующие = _db.Комплектующиеs.
                    Find(Data.Комплектующие.Idкомплектующего);
            }
            AddEditKompl1.DataContext = _комплектующие;
        }

        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbCost.Text == null)
            {
                errors.Append("Установите цену");
            }
            if (tbKolvo.Text == null)
            {
                errors.Append("Напишите кол-во");
            }
            if (tbNameKompl.Text == null) 
            {
                errors.Append("Напишите название комплектующего");
            }
            if (cbIDproiz.SelectedItem == null)
            {
                errors.Append("Выберите ID производителя");
            }
            if (cbIDsklada.SelectedItem == null) 
            {
                errors.Append("Напишите ID склада");
            }
            if (cbTypeKompl.SelectedItem == null)
            {
                errors.Append("Напишите тип комплектующего");
            }
            try
            {
                if (Data.Комплектующие == null)
                {
                    _db.Комплектующиеs.Add(_комплектующие);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}