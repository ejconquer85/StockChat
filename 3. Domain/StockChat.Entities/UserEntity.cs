using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StockChat.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FullName
        {
            get;
            set;
        }

    }
}
