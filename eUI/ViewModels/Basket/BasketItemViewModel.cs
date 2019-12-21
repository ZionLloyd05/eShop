using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eUI.ViewModels.Basket
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
