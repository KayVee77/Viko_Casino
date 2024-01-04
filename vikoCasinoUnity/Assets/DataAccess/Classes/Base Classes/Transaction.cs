using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class Transaction : Entity
    {
        public Transaction(int amount, int user_Id)
        {
            Amount = amount;
            User_Id = user_Id;
        }

        private DateTime DateOfPayment { get; } = DateTime.Now;
        private int Amount { get; }
        private int User_Id { get; }

        public int getAmount()
        {
            return this.Amount;
        }

        public int getUserId() 
        {
            return this.User_Id;
        }
    }
}
