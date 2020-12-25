using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp
{
    public class Contact
    {
        public string _name;
        public string _surname;
        public PhoneNumber _phoneNumber;
        public DateTime _dateOfBirth;
        public string _email;
        public string _vkId;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Введена пустая строка.");

                if (value.Length > 50)
                    throw new ArgumentException("Имя должно быть меньше 50 символов.");

                if (value != string.Empty)
                    _name = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }




        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Введена пустая строка.");

                if (value.Length > 50)
                    throw new ArgumentException("фамилия должна быть меньше 50 символов.");


                if (value != string.Empty)
                    _surname = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }




        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Введена пустая строка.");

                if (value.Length > 50)
                    throw new ArgumentException("email должен быть меньше 50 символов.");
                _email = value;
            }
        }
        public string VkId
        {
            get { return _vkId; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Введена пустая строка.");

                if (value.Length > 15)
                    throw new ArgumentException("id должен быть меньше 15 символов.");
                _vkId = value;
            }
        }
        public PhoneNumber PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Введена пустая строка.");
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                //дата рождения не меньше 1900 и не больше текущего
                if (value.Year < 1900 || value > DateTime.Today)
                    throw new ArgumentException(message: "дата рождения не может быть меньше 1900 и больше текущего.");

                _dateOfBirth = value;
            }
        }
        public Contact(string name, string surname, PhoneNumber phoneNumber, DateTime dateOfBirth, string email, string vkId)
        {

            PhoneNumber = new PhoneNumber();

            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Email = email;
            VkId = vkId;
        }
        public Contact Clone()
        {
            Contact clone = new Contact(Name, Surname, PhoneNumber, DateOfBirth, Email, VkId);
            return clone;
        }
    }
}
