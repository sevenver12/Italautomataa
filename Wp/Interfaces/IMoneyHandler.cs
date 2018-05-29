using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wp.Modell;
namespace Wp.Interfaces
{
    public interface IMoneyHandler
    {
        void FillMoneyPouch(ICollection<Moneyy> list, bool full);
        void InstallMoney(ICollection<Moneyy> list, ref int bank, int ammount);
        IEnumerable<Moneyy> ReturnMoney(ICollection<Moneyy> list, int toReturn);
    }
}
