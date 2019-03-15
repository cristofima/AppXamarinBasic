using AppXamarin.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public User User { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public ICommand OnValidationCommand { get; set; }

        public UserViewModel()
        {
            User = new User();
            this.ValidAction();
        }

        private void ValidAction()
        {
            OnValidationCommand = new Command((obj) =>
            {
                User.FirstName.NotValidMessageError = "Name is required";
                User.FirstName.IsNotValid = string.IsNullOrEmpty(User.FirstName.Name);

                User.Email.NotValidMessageError = "Email is required";
                User.Email.IsNotValid = string.IsNullOrEmpty(User.Email.Name);


                if (string.IsNullOrEmpty(User.Password.Name))
                {
                    User.Password.NotValidMessageError = "Password is required";
                    User.Password.IsNotValid = true;
                }
                else if (User.Password.Name.Length < 5)
                {
                    User.Password.NotValidMessageError = "Password must have more than 5 charcteres";
                    User.Password.IsNotValid = true;
                }
                else
                {
                    User.Password.IsNotValid = false;
                }

            });
        }
    }
}