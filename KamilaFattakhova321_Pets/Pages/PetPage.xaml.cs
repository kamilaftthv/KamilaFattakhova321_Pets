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
    public partial class PetPage : Page
    {
        private User _currentUser;
        private List<Pets> _pets;
        private List<Pets> _filteredPets;

        public PetPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadPets();
        }

        private void LoadPets()
        {
            if (_currentUser.Login == "Admin")
            {
                _pets = DataBaseManager.DataBaseConnection.Pets.ToList();
            }
            else
            {
                _pets = DataBaseManager.DataBaseConnection.Pets
                              .Where(pet => pet.Pet_type.User.Id_user == _currentUser.Id_user)
                              .ToList();
            }
            _filteredPets = _pets;
            PetsDataGrid.ItemsSource = _filteredPets;
        }

        private void SortComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string sortOption = selectedItem.Tag.ToString();
                ApplySorting(sortOption);
            }
        }

        private void ApplySorting(string sortOption)
        {
            switch (sortOption)
            {
                case "TypeAsc":
                    _filteredPets = _filteredPets.OrderBy(p => p.Pet_type.Type).ToList();
                    break;
                case "TypeDesc":
                    _filteredPets = _filteredPets.OrderByDescending(p => p.Pet_type.Type).ToList();
                    break;
                case "NameAsc":
                    _filteredPets = _filteredPets.OrderBy(p => p.Name).ToList();
                    break;
                case "NameDesc":
                    _filteredPets = _filteredPets.OrderByDescending(p => p.Name).ToList();
                    break;
                case "DescriptionAsc":
                    _filteredPets = _filteredPets.OrderBy(p => p.Description).ToList();
                    break;
                case "DescriptionDesc":
                    _filteredPets = _filteredPets.OrderByDescending(p => p.Description).ToList();
                    break;
            }
            PetsDataGrid.ItemsSource = _filteredPets;
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            _filteredPets = _pets.Where(pet => pet.Description.ToLower().Contains(searchText)).ToList();
            PetsDataGrid.ItemsSource = _filteredPets;
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
