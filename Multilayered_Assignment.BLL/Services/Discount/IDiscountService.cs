using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.Discount
{
    public interface IDiscountService
    {
        double GetDiscountBulkBuy(int amount);
    }
}
