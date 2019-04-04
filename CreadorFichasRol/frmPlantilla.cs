using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Xml.Linq;

namespace CreadorFichasRol
{
    public partial class frmPlantilla : Form
    {
        
        public frmPlantilla()
        {
      
            InitializeComponent();
            //MessageBox.Show(txtName.Tag.ToString());
        }
        private void Tirada_Click_1(object sender, EventArgs e)
        {
            using (frmObtenerAtributos frm = new frmObtenerAtributos())
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    txtFue.Text = frm.dic["Fue"];
                    txtInt.Text = frm.dic["Int"];
                    txtSab.Text = frm.dic["Sab"];
                    txtCon.Text = frm.dic["Con"];
                    txtCar.Text = frm.dic["Car"];
                    txtDes.Text = frm.dic["Des"];
                }
                Bonificadores bon = new Bonificadores();
                txtBonFue.Text = bon.GetBonificador(txtFue.Text).ToString();
                txtBonCar.Text = bon.GetBonificador(txtCar.Text).ToString();
                txtBonSab.Text = bon.GetBonificador(txtSab.Text).ToString();
                txtBonInt.Text = bon.GetBonificador(txtInt.Text).ToString();
                txtBonCon.Text = bon.GetBonificador(txtCon.Text).ToString();
                txtBonDes.Text = bon.GetBonificador(txtDes.Text).ToString();
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {               
                
                GuardarXml();
            }

            catch (Exception)
            {
                MessageBox.Show("No se ha podido guardar");
            }
        }

        private void GuardarXml()
        {
            string fecha = DateTime.Now.ToString("ddMMyyyy", CultureInfo.InvariantCulture);
            string path = @".\Recursos\DB\PJ";
            string path2 = txtName.Text + '_' + fecha + ".xml";
            XmlWriter w;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);               
            }           
            if (System.IO.File.Exists(Path.Combine(path, path2)))
            {
               w = XmlWriter.Create(Path.Combine(path, path2) + ".old");              
               
            }
            w = XmlWriter.Create(Path.Combine(path, path2));
            w.WriteStartElement("Personaje");
            w.WriteStartElement("Rasgos");            
            w.WriteElementString(txtName.Tag.ToString(), txtName.Text);
            w.WriteElementString(cbClase.Tag.ToString(), cbClase.Text);
            w.WriteElementString(cbRaza.Tag.ToString(), cbRaza.Text);
            w.WriteEndElement();
            w.WriteStartElement("Atributos");
            w.WriteElementString(txtDes.Tag.ToString(), txtDes.Text);
            w.WriteElementString(txtFue.Tag.ToString(), txtFue.Text);
            w.WriteElementString(txtInt.Tag.ToString(), txtInt.Text);
            w.WriteElementString(txtSab.Tag.ToString(), txtSab.Text);
            w.WriteElementString(txtCar.Tag.ToString(), txtCar.Text);
            w.WriteElementString(txtCon.Tag.ToString(), txtCon.Text);
            w.WriteEndElement();
            w.WriteStartElement("Bonificadores");
            w.WriteElementString(txtBonFue.Tag.ToString(), txtBonFue.Text);
            w.WriteElementString(txtBonSab.Tag.ToString(), txtBonSab.Text);
            w.WriteElementString(txtBonCon.Tag.ToString(), txtBonCon.Text);
            w.WriteElementString(txtBonDes.Tag.ToString(), txtBonDes.Text);
            w.WriteElementString(txtBonCar.Tag.ToString(), txtBonCar.Text);
            w.WriteElementString(txtBonInt.Tag.ToString(), txtBonDes.Text);
            w.WriteEndElement();
            w.WriteEndElement();
            w.Close();
            MessageBox.Show("El fichero ha sido guardado.");
        }

        private void leerXML()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.ShowDialog();

            string fecha = DateTime.Now.ToString("ddMMyyyy", CultureInfo.InvariantCulture);
            string path = @".\Recursos\DB\PJ";
            string path2 = txtName.Text + '_' + fecha + ".xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path.Combine(path, path2));

            XmlNodeList xPersonas = xDoc.GetElementsByTagName("Personajes");
            XmlNodeList xLista = ((XmlElement)xPersonas[0]).GetElementsByTagName("Rasgos");
            foreach (XmlElement nodo in xLista)
            {
                txtName.Text = nodo.GetAttribute("Nombre");
                //txtName.Text = nodo.InnerText;
                cbClase.Text = nodo.GetAttribute("Clase");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cmdMax.Visible = false;
            cmdMin.Visible = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdBar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmdMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            cmdMin.Visible = false;
            cmdMax.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
               
                leerXML();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede cargar");
            }           
        }

        //private void txtExp_TextChanged(object sender, EventArgs e)
        //{
        //    string oldValueExp = lblNivel.Text;
        //    //Int32.TryParse(lblNivel.Text, out oldValueExp);
        //    if (txtExp.Text == "300")
        //    {
        //        lblNivel.Text = "2";
        //    }
        //    if (oldValueExp != lblNivel.Text)
        //    {
        //        button1.Enabled = true;
        //        button2.Enabled = true;
        //        button3.Enabled = true;
        //        button4.Enabled = true;
        //        button5.Enabled = true;
        //        button6.Enabled = true;
        //    }
        //    if (txtExp.Text == "")
        //    {
        //        MessageBox.Show("No puede estar vacio.");
        //        lblNivel.Text = oldValueExp;
        //        button1.Enabled = false;
        //        button2.Enabled = false;
        //        button3.Enabled = false;
        //        button4.Enabled = false;
        //        button5.Enabled = false;
        //        button6.Enabled = false;
        //    }
        //}

    }
}
