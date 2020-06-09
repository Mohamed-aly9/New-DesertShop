using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IStockItemRepository
    {
        IEnumerable<StockItem> AllPies { get; }
        StockItem GetStockItemById(Guid id);

        StockItem GetStockItemByName(string name);
        
    }
}
