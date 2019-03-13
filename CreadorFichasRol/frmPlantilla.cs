using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreadorFichasRol
{
    public partial class frmPlantilla : Form
    {
        enum Atributo { Fue, Int, Con, Des, Sab, Car };   
                int test;
        public frmPlantilla()
        {
            InitializeComponent();
            foreach (string x in Enum.GetNames(typeof(Atributo))) {
                cbAttCar.Items.Add(x);
                cbAttCon.Items.Add(x);
                cbAttDes.Items.Add(x);
                cbAttFue.Items.Add(x);
                cbAttInt.Items.Add(x);
                cbAttSab.Items.Add(x);
            } 
        }
     private int TiradaAtributos()
        {
            do
            {
                int[] array = new int[4];
                var random = new Random();
                //genera tantos numeros como grande sea el array
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(1, 6);
                }
                //ordena los numeros
                Array.Sort(array);
                Array.Reverse(array);
                //suma los tres primeros
                test = array[0] + array[1] + array[2];
            } while (test < 8);            
            return test;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] rellenarAtributos = new int[6];
            for (int i = 0; i < rellenarAtributos.Length; i++)
            {             
              rellenarAtributos[i] = TiradaAtributos();                
            }
            txtFue.Text = TiradaAtributos().ToString();
            txtCar.Text = rellenarAtributos[1].ToString();
            txtCon.Text = rellenarAtributos[2].ToString();
            txtDes.Text = rellenarAtributos[3].ToString();
            txtSab.Text = rellenarAtributos[4].ToString();
            txtInt.Text = rellenarAtributos[5].ToString();
        }        
    }
}
