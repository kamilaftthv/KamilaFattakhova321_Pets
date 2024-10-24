using KamilaFattakhova321_Pets.Data;
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

namespace KamilaFattakhova321_Pets.Pages
{
    /// <summary>
    /// Interaction logic for PetPage.xaml
    /// </summary>
    public partial class PetPage : Page
    {
        public PetPage()
        {
            InitializeComponent();
            LoadPets();
        }

        private void LoadPets()
        {
            var pets = DataBaseManager.DataBaseConnection.Pets.ToList();
            PetsDataGrid.ItemsSource = pets;
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPetPage());
        }
    }
}
