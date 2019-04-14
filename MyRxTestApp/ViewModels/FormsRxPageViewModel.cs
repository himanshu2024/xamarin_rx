using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

namespace MyRxTestApp.ViewModels
{
    public class FormsRxPageViewModel : BaseViewModel
    {
        private const string REGEX_PHONE_VALIDATION = @"^(\+\d{12}|\d{10})$";
        private const string REGEX_NAME_VALIDATION = "^[a-zA-Z]*$";
        private const string REGEX_EMAIL_VALIDATION = "^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$";
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        private string _nameErrorMessage;
        public string NameErrorMessage
        {
            get { return _nameErrorMessage; }
            set
            {
                if (_nameErrorMessage != value)
                {
                    _nameErrorMessage = value;
                    OnPropertyChanged("NameErrorMessage");
                }
            }
        }

        private string _emailErrorMessage;
        public string EmailErrorMessage
        {
            get { return _emailErrorMessage; }
            set
            {
                if (_emailErrorMessage != value)
                {
                    _emailErrorMessage = value;
                    OnPropertyChanged("EmailErrorMessage");
                }
            }
        }

        private string _phoneErrorMessage;
        public string PhoneErrorMessage
        {
            get { return _phoneErrorMessage; }
            set
            {
                if (_phoneErrorMessage != value)
                {
                    _phoneErrorMessage = value;
                    OnPropertyChanged("PhoneErrorMessage");
                }
            }
        }


        private bool _isSubmitEnable;
        public bool IsSubmitEnable
        {
            get { return _isSubmitEnable; }
            set
            {
                if (_isSubmitEnable != value)
                {
                    _isSubmitEnable = value;
                    OnPropertyChanged("IsSubmitEnable");
                }
            }
        }

        public FormsRxPageViewModel()
        {
            _ = Observable.CombineLatest(
            Observable.FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                .Where(x => x.EventArgs.PropertyName == nameof(Name)),
                Observable.FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                .Where(x => x.EventArgs.PropertyName == nameof(Email)),
                Observable.FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                .Where(x => x.EventArgs.PropertyName == nameof(Phone)),
                (Name, Email, Phone) => validate()
                )
                .Subscribe();

        }

        private bool validate()
        {
            bool f = true;
            if (!IsValidString(Name, REGEX_NAME_VALIDATION))
            {
                NameErrorMessage = "Invalid name";
                f = false;
            }
            else
            {
                NameErrorMessage = "";
            }
            if (!IsValidString(Email, REGEX_EMAIL_VALIDATION))
            {
                EmailErrorMessage = "Invalid email";
                f = false;

            }
            else
            {
                EmailErrorMessage = "";

            }
            if (!IsValidString(Phone, REGEX_PHONE_VALIDATION))
            {
                PhoneErrorMessage = "Invalid phone";
                f = false;

            }
            else
            {
                PhoneErrorMessage = "";

            }
            if (f)
            {

                IsSubmitEnable = true;
            }
            else
            {
                IsSubmitEnable = false;
            }

            return f;
        }

        private bool IsValidString(string str, string expression)
        {
            return Regex.IsMatch(str, expression);
        }
    }
}
