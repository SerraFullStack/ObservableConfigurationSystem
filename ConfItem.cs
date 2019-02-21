using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShared.Configuration
{
    public class ConfItem
    {
        public object _value;

        public bool justMemory = false;

        public int AsInt
        {
            get
            {
                return int.Parse(this.AsString);
            }

            set
            {
                _value = value.ToString();
            }
        }

        public string AsString
        {
            get
            {
                if (_value is string)
                    return (string)_value;
                else 
                    return _value.ToString();
            }
            set
            {
                _value = value;
            }
        }

        public double AsDouble
        {
            get
            {
                return double.Parse(this.AsString.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator).Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
            }
            set
            {
                _value = value.ToString();
            }
        }

        public bool AsBoolean
        {
            get
            {
                if ((AsString == "1") || (AsString.ToLower() == "true"))
                    return true;
                else
                    return false;
            }
            set
            {
                _value = value.ToString();
            }
        }

        public T AsT<T>()
        {
            if (_value is T)
                return (T)_value;
            else
            {
                var parseMethod = _value.GetType().GetMethod("Parse");
                if (parseMethod != null)
                    return (T)parseMethod.Invoke(null, new object[] { AsString });
                else
                {
                    throw new InvalidCastException("Cant convert an " + _value.GetType().ToString() + " to desired type");
                }
            }
        }



        public void Set(object value)
        {
            if (value is string)
                AsString = (string)value;
            else if (value is int)
                AsInt = (int)value;
            else if (value is double)
                AsDouble = (double)value;
            else if (value is bool)
                AsBoolean = (bool)value;
            else
                _value = value;

                //throw new InvalidCastException("Invalid value type");
        }
    }
}
