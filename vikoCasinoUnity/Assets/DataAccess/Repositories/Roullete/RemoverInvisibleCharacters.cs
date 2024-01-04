using Assets.DataAccess.Interfaces.Roullete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DataAccess.Repositories.Roullete
{
    public class RemoverInvisibleCharacters : IRemoverInvisibleCharacters
    {
        public string RemoveInvisibleCharacters(string str)
        {
            return new string(str.Where(c => !char.IsControl(c) && c != 0x200B && c != 0xFEFF).ToArray());
        }
    }
}
