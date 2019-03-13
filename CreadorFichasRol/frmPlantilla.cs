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
            for (int i = 0; i < array.Length-1; i++)
            {
                test += array[i];
                    //MessageBox.Show(i.ToString());                
            }
            return test;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            do
            {
                TiradaAtributos();
            }
            while (test < 8);
            //txtFuerza.Text = test.ToString();
            test = 0;
      
            
        }

        private void cbAttFue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
