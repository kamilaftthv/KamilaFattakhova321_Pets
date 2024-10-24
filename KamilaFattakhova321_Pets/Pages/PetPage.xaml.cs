using KamilaFattakhova321_Pets.Data;
using KamilaFattakhova321_Pets.DbConnection;
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
        private User _currentUser;

        public PetPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadPets();
        }

        private void LoadPets()
        {
            var pets = DataBaseManager.DataBaseConnection.Pets
                       .Where(pet => pet.Pet_type.User.Id_user == _currentUser.Id_user).ToList();
            PetsDataGrid.ItemsSource = pets;
        }
        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPetPage());
        }
        private void PetPageButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserPage(_currentUser));
        }
    }
}
