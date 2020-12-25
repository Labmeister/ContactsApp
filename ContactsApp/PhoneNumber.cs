using System;

namespace ContactsApp
{
    public class PhoneNumber
    {
        string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Введена пустая строка.");

                if (value.Length > 10)
                    throw new ArgumentException("Номер слишком длинный.");

                _number = "7" + value;
            }

        }
    }
   
}



