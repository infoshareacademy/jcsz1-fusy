using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Models
{
    public class User : IdentityUser
    {
        public List<Currency> FavouriteCurrencies { get; set; }
    }
}
