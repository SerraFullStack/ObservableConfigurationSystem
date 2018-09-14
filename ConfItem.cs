using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidaiDataTools.Shared.Configuration
{
    public class ConfItem
    {
        public string _value;

        public int AsInt
        {
            get
            {
                return int.Parse(this._value);
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
                return this._value;
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
                return double.Parse(this._value.Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator).Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
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
                if ((_value == "1") || (_value.ToLower() == "true"))
                    return true;
                else
                    return false;
            }
            set
            {
                _value = value.ToString();
            }
        }

        public void TrySet(object value)
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
                throw new InvalidCastException("Invalid value type");
        }
    }
}
