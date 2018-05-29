using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wp.Interfaces;
using Wp.Modell;

namespace Wp.Services
{
    public class MoneyHandler : IMoneyHandler
    {
        public void FillMoneyPouch(ICollection<Moneyy> list, bool full)
        {
            int quantity = full ? 10 : 1;
            list.Add(new Moneyy { Value = 100, Quantity = quantity });
            list.Add(new Moneyy { Value = 50, Quantity = quantity });
            list.Add(new Moneyy { Value = 20, Quantity = quantity });
            list.Add(new Moneyy { Value = 10, Quantity = quantity });
            list.Add(new Moneyy { Value = 5, Quantity = quantity });
        }

        public void InstallMoney(ICollection<Moneyy> list,ref int bank, int ammount)
        {
            var valami = list.FirstOrDefault(fod => fod.Value == ammount);
            if (valami ==null || valami.Quantity == 10) bank += ammount;
            else valami.Quantity++;
        }

        public IEnumerable<Moneyy> ReturnMoney(ICollection<Moneyy> list,int toReturn)
        {
            if (toReturn > list.Sum(s => s.Sum7)) yield break;
            else
            {
                foreach (var fe in list)
                {
                    int oddments = (int)Math.Floor(Decimal.Divide(toReturn,fe.Value));
                    if (oddments > 7) oddments = 7;
                    int leftover = oddments > 0? toReturn % (fe.Value * oddments) : toReturn;
                    fe.Quantity -= oddments;
                    toReturn = leftover;
                    if (oddments > 0) yield return new Moneyy { Quantity = oddments, Value = fe.Value };
                }
              

            }
        }
    }
}
