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

namespace KamilaFattakhova321_Pets.Pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private User _currentUser;
        public UserPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (_currentUser != null)
            {
                FullNameTextBlock.Text = _currentUser.FullName;
                LoginTextBlock.Text = _currentUser.Login;
                PasswordTextBlock.Text = _currentUser.Password;

                if (_currentUser.Photo != null && _currentUser.Photo.Length > 0)
                {
                    var image = new BitmapImage();
                    using (var mem = new System.IO.MemoryStream(_currentUser.Photo))
                    {
                        image.BeginInit();
                        image.StreamSource = mem;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                    }
                    Photo.Source = image;
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void PetPageButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PetPage(_currentUser));
        }

        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new System.Uri(openFileDialog.FileName));

                Photo.Source = image;

                using (var stream = new System.IO.MemoryStream())
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(stream);
                    _currentUser.Photo = stream.ToArray();
                }
            }
        }
    }
}
