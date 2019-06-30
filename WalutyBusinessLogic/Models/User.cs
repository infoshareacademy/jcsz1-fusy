using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WalutyBusinessLogic.Models
{
    public class User : IdentityUser
    {
        public virtual List<UserCurrency> UserFavoriteCurrencies { get; set; }
    }
}
