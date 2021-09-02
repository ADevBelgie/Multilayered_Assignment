using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.Discount
{
    public class DiscountService: IDiscountService
    {
        // Idea: Add list of discountrules 
       
        public double GetDiscountBulkBuy(int amount)
        {
            if (amount >= 6)
            {
                return 0.10;
            }
            else if (amount >= 3)
            {
                return 0.05;
            }
            else
            {
                return 0.00;
            }
        }
    }
}
