using antiokas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace antiokas.Services
{
    public class SevantisAccountService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public SevantisAccountService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateSevantisAccount(string Name,string Surname,string userId ,decimal initialCredit)
        {
            var accountNumber = (12345 + db.SevantisAccounts.Count()).ToString().PadLeft(10, '0');
            var sevantisAccount = new SevantisAccount { FirstName = Name, LastName = Surname, AccountNumber = accountNumber, Credit = 0, ApplicationUserId = userId };
            db.SevantisAccounts.Add(sevantisAccount);
            db.SaveChanges();
        }
    }
}