using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CreadorFichasRol
{
    public partial class frmValidator : Form
    {
        public frmValidator()
        {
            InitializeComponent();
        }
        public int ValidarPlantilla()
        {
            int count = 0;
            using (frmPlantilla frm = new frmPlantilla())
            {
                if (frm.txtName.Text == "" && frm.textBox3.Text == "")
                {
                    count += 1;
                }
            }

            return count;
        }

        internal Boolean ValidarAtributos(ComboBox[] arrayAtributos)
        {
            int countLeer = 0;
            string vacio = "";
            //Con este array miro que no esten vacios
            for (int i = 0; i <= arrayAtributos.Length - 1; i++)
            {
                if (arrayAtributos[i].Text == "")
                {
                    countLeer += 1;
                    vacio += Environment.NewLine + arrayAtributos[i].Tag.ToString();
                }
            }
            if (countLeer > 0)
            {
                MessageBox.Show("El siguiente campo esta vacio: " + vacio);
                return false;
            }
            IEnumerable<IGrouping<string, ComboBox>> groups = arrayAtributos.GroupBy(x => x.Text);
            IGrouping<string, ComboBox> largest = groups.OrderByDescending(x => x.Count()).First();
            string name = largest.Key;
            if (largest.Count() != 1)
            {
                MessageBox.Show("El siguiente campo esta repetido: " + name);
                return false;
            }
            return true;
        }
        public Boolean ValidarValoresAtributos(TextBox[] arrayValores)
        {
            for (int i = 0; i <= arrayValores.Length - 1; i++)
            {
                if (arrayValores[i].Text == "")
                {
                    MessageBox.Show("Debes realizar una tirada!!!");
                    return false;
                }
            }
            return true;
        }
    }
}
