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
using kyrovaya.xamls;
using System.Reflection;

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
        private void WindowInitialized(object sender, EventArgs e)
        {
            Autorize f = new Autorize();
            f.ShowDialog();
            menu.IsEnabled = true;
            if (Data.Login == false) Close();
            if (Data.Right == "Администратор")
                if (Data.Right == "Менеджер")
                {
                    menu.IsEnabled = true;
                }   
            else
            {

                menu.IsEnabled = false;
            }
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
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Комплектующие row = (Комплектующие)dg1.SelectedItem;
                    if (row != null)
                    {
                        using (KyrsovayaContext _db = new KyrsovayaContext())
                        {
                            _db.Комплектующиеs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBInDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else dg1.Focus();
        }
        private void LoadOrders()
        {
            using (KyrsovayaContext _db = new KyrsovayaContext())
            {
                int selectedIndex = ordersDataGrid.SelectedIndex;

                // Загружаем заказы с данными о комплектующих и складах
                var orders = _db.Заказыs
                    .Include(o => o.IdкомплектующегоNavigation) // Используем навигационное свойство
                    .Include(o => o.IdскладаNavigation) // Используем навигационное свойство
                    .ToList();

                // Формируем новый список для отображения
                var orderDisplayList = orders.Select(o => new
                {
                    o.Idзаказа, // Идентификатор заказа
                    ComponentName = o.IdкомплектующегоNavigation?.НазваниеКомплектующего ?? "Неизвестно", // Название комплектующего
                    StockName = o.IdскладаNavigation?.Location ?? "Неизвестно", // Название склада
                    o.Количество, // Количество
                    o.ДатаЗаказа // Дата заказа
                }).ToList();

                // Привязываем новый список к DataGrid
                ordersDataGrid.ItemsSource = orderDisplayList;

                // Восстанавливаем индекс выбора
                if (selectedIndex != -1)
                {
                    if (selectedIndex >= ordersDataGrid.Items.Count) selectedIndex--;
                    ordersDataGrid.SelectedIndex = selectedIndex;
                    ordersDataGrid.ScrollIntoView(ordersDataGrid.SelectedItem);
                }

                ordersDataGrid.Focus();
            }
        }
        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Right == "Менеджер")
            {
                if (ordersDataGrid.Visibility == Visibility.Visible)
                {
                    ordersDataGrid.Visibility = Visibility.Hidden;
                }
                else
                {
                    ordersDataGrid.Visibility = Visibility.Visible;
                    LoadOrders();
                }
            }
            else
            {
                MessageBox.Show("У вас нет прав для просмотра заказов.");
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, авторизован ли клиент
            if (Data.Right != "Клиент")
            {
                MessageBox.Show("Пожалуйста, войдите как клиент, чтобы сделать заказ.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаем новую форму для заказа
            OrderForm orderForm = new OrderForm();
            orderForm.Owner = this;

            // Открываем форму для заказа
            if (orderForm.ShowDialog() == true)
            {
                LoadDBInDataGrid(); // Обновляем данные
            }
        }

        private void btnProizv_Click(object sender, RoutedEventArgs e)
        {
            Proizvod f = new Proizvod();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void btnType_CLick(object sender, RoutedEventArgs e)
        {
            xamls.Type f = new xamls.Type();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void btnSklad_Click(object sender, RoutedEventArgs e)
        {
            Sklad f = new Sklad();  
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }
    }
}