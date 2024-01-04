using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class User : Entity
    {
        public User(string username, string password, string email, DateTime dateOfBirth, int balance_Id, int percentOfWin)
        {

            Username = username;
            Password = password;
            Email = email;
            DateOfBirth = dateOfBirth;
            Balance_Id = balance_Id;
            PercentOfWin = percentOfWin;
        }

        private string Username { get; }
        private string Password { get; }
        private string Email { get; }
        private DateTime DateOfBirth { get; }
        private int Balance_Id { get; }
        private int PercentOfWin { get; set; }


        public void setPercentOfWin(int percentOfWin)
        {
            this.PercentOfWin = percentOfWin;
        }
        public int getPercentOfWin()
        {
            return this.PercentOfWin;
        }
        public int getBalanceId()
        {
            return (int)this.Balance_Id;
        }
        public DateTime getDateOfBirth()
        {
            return this.DateOfBirth;
        }
        public string getEmail()
        {
            return this.Email;
        }
        public string getPassword()
        {
            return this.Password;
        }
        public string getUsername()
        {
            return this.Username;
        }
        public int getId()
        {
            return this.Id;
        }

    }
}
