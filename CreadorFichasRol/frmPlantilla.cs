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
                int resultado;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int[] dados = new int[4];
            var random = new Random();
            int[] atributos = new int[6];
            for (int x = 0; x < atributos.Length; x++)
            {
                do
                {
                    for (int i = 0; i < dados.Length; i++)
                    {
                        dados[i] = random.Next(1, 7);
                    }
                    Array.Sort(dados);
                    Array.Reverse(dados);
                    resultado = dados[0] + dados[1] + dados[2];
                    atributos[x] = resultado;
                } while (resultado < 8);          
            }          
                txtFue.Text = atributos[0].ToString();
                txtCar.Text = atributos[1].ToString();
                txtCon.Text = atributos[2].ToString();
                txtDes.Text = atributos[3].ToString();
                txtSab.Text = atributos[4].ToString();
                txtInt.Text = atributos[5].ToString();
            Bonificadores();
        }

         private void Bonificadores()
        {
            Int32.TryParse(txtFue.Text, out int Fue);
            txtBonFue.Text = ((Fue - 10) / 2).ToString();
        }   
    }
}
