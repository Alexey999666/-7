using System.Data.Common;
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
using System.Xml.Linq;
using Lib_14;
using System;

namespace практос_7
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
        /// <summary>
        /// метод для выхода из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// метод для информирования о задании
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создать класс Liquid (жидкость), имеющий поля названия, плотности и объема. Создать необходимые методы и свойства. Создать перегруженные методы SetParams, для установки параметров жидкости.", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// метод для информирования о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Андрианов Алексей Вариант 14.", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// метод для очистки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tbDensityInput.Clear();
            tbDensityOutput.Clear();
            tbNameInput.Clear();
            tbNameOutput.Clear();
            tbVolumeInput.Clear();
            tbVolumeOutput.Clear();
            tbHopsPercentageInput.Clear();
            tbHopsPercentageOutput.Clear();
            tbStrengthInput.Clear();
            tbStrengthOutput.Clear();

        }
        Liquid liquid = new Liquid("",0,0);
        Alcohol alcohol = new Alcohol("",0,0,0);
        Beer beer = new Beer("",0,0,0,0);
        bool flagFillFullLiquid = false;
        bool flagFillFullAlcohol = false;
        bool flagFillFullBeer = false;
        /// <summary>
        /// метод для первоначальной записи характеристик 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbDensityInput.Text, out int densityLiquid) && densityLiquid > 0 && int.TryParse(tbVolumeInput.Text, out int volumeLiquid) && volumeLiquid > 0 && tbNameInput.Text != "" && string.IsNullOrWhiteSpace(tbStrengthInput.Text) && string.IsNullOrWhiteSpace(tbHopsPercentageInput.Text))
            {
                string nameLiquid = tbNameInput.Text;
                liquid.SetParams(nameLiquid, densityLiquid,volumeLiquid);
                flagFillFullLiquid = true;
                flagFillFullAlcohol = false;
                flagFillFullBeer = false;
                MessageBox.Show("Значения жидкости присвоенны", "Выполнено", MessageBoxButton.OK);
            }
            else if (int.TryParse(tbDensityInput.Text, out int densityAlcohol) && densityAlcohol > 0 && int.TryParse(tbVolumeInput.Text, out int volumeAlcohol) && volumeAlcohol > 0 && tbNameInput.Text != "" && double.TryParse(tbStrengthInput.Text, out double strengthAlcohol) && strengthAlcohol > 0 && string.IsNullOrWhiteSpace(tbHopsPercentageInput.Text))
            {
                string nameAlcohol = tbNameInput.Text;
                alcohol.SetStrength(nameAlcohol, densityAlcohol, volumeAlcohol, strengthAlcohol);
                flagFillFullLiquid = false;
                flagFillFullAlcohol = true;
                flagFillFullBeer = false;
                MessageBox.Show("Значения алкоголя присвоенны", "Выполнено", MessageBoxButton.OK);
            }
            else if (int.TryParse(tbDensityInput.Text, out int densityBeer) && densityBeer > 0 && int.TryParse(tbVolumeInput.Text, out int volumeBeer) && volumeBeer > 0 && tbNameInput.Text != "" && double.TryParse(tbStrengthInput.Text, out double strengthBeer) && strengthBeer > 0 && double.TryParse(tbHopsPercentageInput.Text, out double HopsPercentageBeer) && HopsPercentageBeer > 0)
            {
                string nameBeer = tbNameInput.Text;
                beer.SetHopsPercentage(nameBeer, densityBeer, volumeBeer, strengthBeer, HopsPercentageBeer);
                flagFillFullLiquid = false;
                flagFillFullAlcohol = false;
                flagFillFullBeer = true;
                MessageBox.Show("Значения пива присвоенны", "Выполнено", MessageBoxButton.OK);
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// метод для изменения параметров 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (flagFillFullLiquid == true && flagFillFullAlcohol == false && flagFillFullBeer == false)
            {
                if (tbNameInput.Text != "") liquid.Name = tbNameInput.Text;
                if (int.TryParse(tbDensityInput.Text, out int densityLiquid) && densityLiquid > 0) liquid.Density = densityLiquid;
                if (int.TryParse(tbVolumeInput.Text, out int volumeLiquid) && volumeLiquid > 0) liquid.Volume = volumeLiquid;

            }
            else if (flagFillFullLiquid == false && flagFillFullAlcohol == true && flagFillFullBeer == false)
            {
                if (tbNameInput.Text != "") alcohol.Name = tbNameInput.Text;
                if (int.TryParse(tbDensityInput.Text, out int densityAlcohol) && densityAlcohol > 0) alcohol.Density = densityAlcohol;
                if (int.TryParse(tbVolumeInput.Text, out int volumeAlcohol) && volumeAlcohol > 0) alcohol.Volume = volumeAlcohol;
                if (double.TryParse(tbStrengthInput.Text, out double strengthAlcohol) && strengthAlcohol > 0) alcohol.Strength =strengthAlcohol;
            }
            else if (flagFillFullLiquid == false && flagFillFullAlcohol == false && flagFillFullBeer == true)
            {
                if (tbNameInput.Text != "") beer.Name = tbNameInput.Text;
                if (int.TryParse(tbDensityInput.Text, out int densityBeer) && densityBeer > 0) beer.Density = densityBeer;
                if (int.TryParse(tbVolumeInput.Text, out int volumeBeer) && volumeBeer > 0) beer.Volume = volumeBeer;
                if (double.TryParse(tbStrengthInput.Text, out double strengthAlcohol) && strengthAlcohol > 0) beer.Strength = strengthAlcohol;
                if (double.TryParse(tbHopsPercentageInput.Text, out double HopsPercentageBeer) && HopsPercentageBeer > 0) beer.HopsPercentage = HopsPercentageBeer;
            }
            else MessageBox.Show("Введите правильное значение или запишите значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// метод для вывода параметров 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowLiquid_Click(object sender, RoutedEventArgs e)
        {
            if (flagFillFullLiquid == true)
            {
                tbVolumeOutput.Text = Convert.ToString(liquid.Volume);
                tbDensityOutput.Text = Convert.ToString(liquid.Density);
                tbNameOutput.Text = liquid.Name;
            }
            else if (flagFillFullAlcohol == true)
            {
                tbVolumeOutput.Text = Convert.ToString(alcohol.Volume);
                tbDensityOutput.Text = Convert.ToString(alcohol.Density);
                tbStrengthOutput.Text = Convert.ToString(alcohol.Strength);
                tbNameOutput.Text = alcohol.Name;
            }
            else if (flagFillFullBeer == true)
            {
                tbVolumeOutput.Text = Convert.ToString(beer.Volume);
                tbDensityOutput.Text = Convert.ToString(beer.Density);
                tbStrengthOutput.Text = Convert.ToString(beer.Strength);
                tbHopsPercentageOutput.Text = Convert.ToString(beer.HopsPercentage);
                tbNameOutput.Text = beer.Name;
            }
            else MessageBox.Show("Введите характеристики", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
