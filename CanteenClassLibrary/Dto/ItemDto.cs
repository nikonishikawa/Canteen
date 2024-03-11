using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Dto
{
    public class ItemDto
    {
        public long ItemId { get; set; }

        public string Item { get; set; }

        public string? Description { get; set; }

        public string? FoodImage { get; set; }

        public int IsHalal { get; set; }

        public decimal Price { get; set; }

        public long Category { get; set; }
    }
}
