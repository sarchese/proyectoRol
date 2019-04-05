using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreadorFichasRol
{
    public class Bonificadores
    {
        public int GetBonificador(string valor)
        {
            int num;
            int numbase = 5;
            int bono;
            Int32.TryParse(valor, out num);
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                {
                    numbase++;
                }
            }
            bono = num - numbase;
            return bono;
        }
    }
}