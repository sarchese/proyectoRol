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
    public partial class Form1 : Form
    {
        int test;
        public Form1()
        {
            InitializeComponent();
            Tirada();
        }


        private void Tirada()
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
            //muestra en pantalla
            MessageBox.Show(test.ToString());

        }




    }
}
