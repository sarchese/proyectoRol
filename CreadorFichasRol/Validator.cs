using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreadorFichasRol
{
    class Validator
    {
        public int Validar()
        {
            int[] array = new int[5];
            int count = 0;
            return count;
        }

        public int ValidarPlantilla()
        {
            int count = 0;
            using (frmPlantilla frm = new frmPlantilla())
                if (frm.txtName.Text == "" && frm.textBox3.Text == "")
                {
                    count += 1;
                }
            return count;
        }

        internal int ValidarAtributos(string[] arrayAtributos)
        {
            int count = 0;
            //Con este array miro que no esten vacios
            for (int i = 0; i <= arrayAtributos.Length - 1; i++)
            {
                if (arrayAtributos[i] == "")
                {
                    count += 1;
                }
            }
            var groups = arrayAtributos.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();

            if (largest.Count() != 1)
            {
                count += 1;
            }
            
            return count;
        }
    }
}
