using Dektoon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dektoon.Services
{
    public interface IDektoonServices
    {
        List<CartoonModel> GetCartoon();
        string AddCartoon(CartoonModel cartoon);
        string UpdateCartoon(CartoonModel cartoon);
        string DeleteCartoon(int cartoonId);
    }
}