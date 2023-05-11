using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Core.Services
{
    public interface IProductService
    {
        // bestaande code...

        void UpdateProductStock(int productId, int newStock);
        // andere noodzakelijke methoden...
    }

}
