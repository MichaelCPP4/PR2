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
using LibMas_1;
using Lib_1;

namespace WPF_A2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Заполнение таблицы
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int n;
            int limit;

            if (int.TryParse(textBoxVvod.Text, out n) && int.TryParse(textBoxLimit.Text, out limit))
            {
                //Matematik.InitArr(out mas, element, limit);
                mas = ArrayMetod.RandomMas(n, 1, limit);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;

            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void Calculate_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxVivod.Text = Matematik.Sum(mas).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные!", "Error!!!");
                return;
            }
        }

        private void Clear_ButtonClick(object sender, RoutedEventArgs e)
        {

            if (mas != null)
            {
                textBoxVvod.Clear();
                textBoxVivod.Clear();
                textBoxLimit.Clear();
                dataGrid.ItemsSource = null;
            }
        }

        private void Exit_ButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Info_ClickButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №2 \n Выполнил Иванов Михаил ИСП-31  \n" + "Задание:" + "Ввести n целых чисел." +
                " Найти сумму чисел > 5. Результат вывести на экран.\n", "О программе");
        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                ArrayMetod.SaveArr(ref mas);
            }
        }

        private void Open_ButtonClick(object sender, RoutedEventArgs e)
        {
            ArrayMetod.OpenArr(ref mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
    }
}