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
    public partial class frmObtenerAtributos : Form
    {
        enum Atributo { Fue, Sab, Con, Des, Car, Int };        
        public IDictionary<string, string> dic = new Dictionary<string, string>();
        public int resultado;
        public frmObtenerAtributos()
        {
            InitializeComponent();
            foreach (string x in Enum.GetNames(typeof(Atributo)))
            {
                cb1.Items.Add(x);                
                cb2.Items.Add(x);                
                cb3.Items.Add(x);               
                cb4.Items.Add(x);               
                cb5.Items.Add(x);              
                cb6.Items.Add(x);                 
            }
            SelectionCBStart();
        }
        private void Tirada_Click(object sender, EventArgs e)
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
            txt1.Text = atributos[0].ToString();
            txt4.Text = atributos[1].ToString();
            txt5.Text = atributos[2].ToString();
            txt6.Text = atributos[3].ToString();
            txt3.Text = atributos[4].ToString();
            txt2.Text = atributos[5].ToString();
        }
     
        private void cmdSave_Click(object sender, EventArgs e)
        {
            ComboBox[] aComboBox = { cb1, cb2, cb3, cb4, cb5, cb6};
            TextBox[] aTextBox = {txt1, txt2, txt3, txt4, txt5, txt6 };
            frmValidator validator = new frmValidator();
            if (validator.ValidarAtributos(aComboBox) == false) { return; }
            if (validator.ValidarValoresAtributos(aTextBox) == false) { return; }                        
            dic.Add(cb1.Text, txt1.Text);
            dic.Add(cb2.Text, txt2.Text);
            dic.Add(cb3.Text, txt3.Text);
            dic.Add(cb4.Text, txt4.Text);
            dic.Add(cb5.Text, txt5.Text);
            dic.Add(cb6.Text, txt6.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void SelectionCBStart()
        {
            cb1.SelectedItem = Atributo.Fue.ToString();
            cb2.SelectedItem = Atributo.Sab.ToString();
            cb3.SelectedItem = Atributo.Con.ToString();
            cb4.SelectedItem = Atributo.Des.ToString();
            cb5.SelectedItem = Atributo.Car.ToString();
            cb6.SelectedItem = Atributo.Int.ToString();
        }
    }
}
