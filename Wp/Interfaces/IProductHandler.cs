using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wp.Modell;
namespace Wp.Interfaces
{
    public interface IProductHandler
    {
        void GetProducts(ICollection<Product> list);

    }
}
