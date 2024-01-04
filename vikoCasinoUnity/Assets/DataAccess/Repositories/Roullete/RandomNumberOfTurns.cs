using Assets.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories
{
    public class RandomNumberOfTurns : IRandomNumberOfTurns
    {
        public int GetNumberOfTurns()
        {
            return new Random().Next(90, 150);
        }
    }
}
