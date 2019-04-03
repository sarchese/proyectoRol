using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreadorFichasRol
{
    public class Bonificadores
    {           
        int num;
        public int GetBonificador(string valor)
        {
            Int32.TryParse(valor, out num);
            if (num == 8 || num == 9)
            {
                return -1;
            }
            else
                return (num - 10) / 2;
        }
    }
}
