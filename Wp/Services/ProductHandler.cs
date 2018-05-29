using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wp.Interfaces;
using Wp.Modell;

namespace Wp.Services
{
    public class ProductHandler : IProductHandler
    {
        public void GetProducts(ICollection<Product> list)
        {
            for (int i = 1; i < 11; i++)
            {
                list.Add(new Product
                {
                    Id = i,
                    Name = $"Termék{i}",
                    Price = i * 10
                });
            }
        }
    }
}
