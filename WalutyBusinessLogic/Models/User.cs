using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Models
{
    public class User : IdentityUser
    {
        public virtual List<UserCurrency> UserFavoriteCurrencies { get; set; }
    }
}
