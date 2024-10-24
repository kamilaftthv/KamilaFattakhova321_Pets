using KamilaFattakhova321_Pets.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KamilaFattakhova321_Pets
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создание главного окна
            MainWindow mainWindow = new MainWindow();
            mainWindow.Content = new PetPage(); // Установка PetPage как начальной страницы
            mainWindow.Show();
        }
    }
}
