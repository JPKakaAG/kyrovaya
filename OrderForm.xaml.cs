using Class1;
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

namespace kyrovaya
{
    /// <summary>
    /// Логика взаимодействия для OrderForm.xaml
    /// </summary>
    public partial class OrderForm : Window
    {
        public OrderForm()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }
        KyrsovayaContext _db = new KyrsovayaContext();
        private void CmbWarehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Выводим ID выбранного склада для отладки
            if (cmbWarehouse.SelectedValue != null)
            {
                int warehouseId = (int)cmbWarehouse.SelectedValue;
                Console.WriteLine($"Выбран ID Склада: {warehouseId}");
            }
        }
        private void CmbComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Выводим ID выбранного комплектующего для отладки
            if (cmbComponents.SelectedValue != null)
            {
                int componentId = (int)cmbComponents.SelectedValue;
                Console.WriteLine($"Выбран ID Комплектующего: {componentId}");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComponents();
            LoadWarehouses();
            cmbComponents.SelectionChanged += CmbComponents_SelectionChanged;
            cmbWarehouse.SelectionChanged += CmbWarehouse_SelectionChanged;

        }
        private void LoadWarehouses()
        {
            using (KyrsovayaContext db = new KyrsovayaContext())
            {
                var warehouses = db.Складs.ToList();
                cmbWarehouse.ItemsSource = warehouses;
                cmbWarehouse.DisplayMemberPath = "Location";
                cmbWarehouse.SelectedValuePath = "Idсклада";
            }
        }

        private void LoadComponents()
        {
            using (KyrsovayaContext db = new KyrsovayaContext())
            {
                var components = db.Комплектующиеs.ToList();
                cmbComponents.ItemsSource = components;
                cmbComponents.DisplayMemberPath = "НазваниеКомплектующего";
                cmbComponents.SelectedValuePath = "Idкомплектующего";
            }
        }
        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем выбранные значения
            if (cmbComponents.SelectedValue == null || cmbWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите комплектующее и склад.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int componentId = (int)cmbComponents.SelectedValue; // Используем выбранное значение
            int warehouseId = (int)cmbWarehouse.SelectedValue; // Используем выбранное значение
            int quantity = int.TryParse(txtQuantity.Text, out var qty) ? qty : 0;

            using (KyrsovayaContext db = new KyrsovayaContext())
            {
                // Находим комплектующее
                var component = db.Комплектующиеs.FirstOrDefault(c => c.Idкомплектующего == componentId);

                if (component != null && component.КолвоНаСкладе >= quantity) // Проверяем, достаточно ли на складе
                {
                    // Создаем новый заказ
                    var order = new Заказы
                    {
                        Idкомплектующего = componentId,
                        Iduser = Data.CurrentUserId, // используем текущего пользователя
                        Idсклада = warehouseId,
                        Количество = quantity,
                        ДатаЗаказа = DateTime.Now // Устанавливаем дату заказа
                    };

                    db.Заказыs.Add(order);
                    component.КолвоНаСкладе -= quantity; // Уменьшаем количество на складе
                    db.SaveChanges(); // Сохраняем изменения в базе
                    MessageBox.Show("Заказ успешно создан!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Недостаточно комплектующих на складе или комплектующее не найдено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            this.DialogResult = true; // Закрываем форму с результатом
            this.Close();
        }
    }
}
