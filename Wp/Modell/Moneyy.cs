using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wp.Helper;
namespace Wp.Modell
{
   public class Moneyy : Observable
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set {Set(ref _value , value); }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { Set(ref _quantity ,value); }
        }


        public int Sum { get { return Value * Quantity; } }
        public int Sum7 { get { return Value * Quantity - (3 * Value); } }

    }
}
