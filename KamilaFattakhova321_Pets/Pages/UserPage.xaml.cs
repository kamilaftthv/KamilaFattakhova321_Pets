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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            var user = DataBaseManager.DataBaseConnection.User.FirstOrDefault(u => u.Id_user == 1);
            
            if (user != null)
            {
                FullNameTextBlock.Text = user.FullName;
                LoginTextBlock.Text = user.Login;
                PasswordTextBlock.Text = user.Password;

                if (user.Photo != null)
                {
                    var image = new BitmapImage();
                    using (var mem = new System.IO.MemoryStream(user.Photo))
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
    }
}
