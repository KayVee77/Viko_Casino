using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class Balance : Entity
    {
        public Balance(decimal amount)
        {
            this.Amount = amount;
        }
        public Balance(int id,decimal amount)
        {
            this.Id = id;
            this.Amount = amount;
        }

        private decimal Amount {  get; set; }

        public void setAmount(decimal x)
        {
            this.Amount = x;
        }
        public decimal getAmount() 
        {
            return this.Amount;
        }

        public override string ToString()
        {
            return getAmount().ToString();
        }
    }
}
