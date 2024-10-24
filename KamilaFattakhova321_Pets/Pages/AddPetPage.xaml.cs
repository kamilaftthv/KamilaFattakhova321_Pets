using KamilaFattakhova321_Pets.Data;
using KamilaFattakhova321_Pets.DbConnection;
using Microsoft.Win32;
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
using System.IO;

namespace KamilaFattakhova321_Pets.Pages
{
    /// <summary>
    /// Interaction logic for AddPetPage.xaml
    /// </summary>
    public partial class AddPetPage : Page
    {
        private byte[] _imageData;

        public AddPetPage()
        {
            InitializeComponent();
            LoadPetTypes();
        }

        private void LoadPetTypes()
        {
            var types = DataBaseManager.DataBaseConnection.Pet_type.ToList();
            TypeComboBox.ItemsSource = types;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                _imageData = File.ReadAllBytes(openFileDialog.FileName);
                ImageTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && TypeComboBox.SelectedItem != null)
            {
                var newPet = new Pets
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Id_type = (int)TypeComboBox.SelectedValue,
                    Picture = _imageData
                };

                DataBaseManager.DataBaseConnection.Pets.Add(newPet);
                DataBaseManager.DataBaseConnection.SaveChanges();
                MessageBox.Show("Питомец добавлен!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
