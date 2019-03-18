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
            int test = 0;
            using (frmPlantilla frm = new frmPlantilla())
                if (frm.txtName.Text == "")
                {
                    test += 1;
                }
            return test;
        }

    }
}
