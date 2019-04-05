using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
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
        private List<TextBox> CrearLista()
        {
            List<TextBox> miListaDeDatos = new List<TextBox>();
            miListaDeDatos.Add(txtName);
            miListaDeDatos.Add(txtCar);
            miListaDeDatos.Add(txtFue);
            miListaDeDatos.Add(txtCon);
            miListaDeDatos.Add(txtDes);
            miListaDeDatos.Add(txtInt);
            miListaDeDatos.Add(txtSab);
            miListaDeDatos.Add(txtBonCar);
            miListaDeDatos.Add(txtBonFue);
            miListaDeDatos.Add(txtBonCon);
            miListaDeDatos.Add(txtBonDes);
            miListaDeDatos.Add(txtBonInt);
            miListaDeDatos.Add(txtBonSab);
            return miListaDeDatos;
        }
        private void btnTirada_Click(object sender, EventArgs e)
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
        private void btnGuardar_Click(object sender, EventArgs e)
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
            w.WriteElementString(txtFue.Tag.ToString(), txtFue.Text);
            w.WriteElementString(txtDes.Tag.ToString(), txtDes.Text);
            w.WriteElementString(txtCon.Tag.ToString(), txtCon.Text);
            w.WriteElementString(txtInt.Tag.ToString(), txtInt.Text);
            w.WriteElementString(txtSab.Tag.ToString(), txtSab.Text);
            w.WriteElementString(txtCar.Tag.ToString(), txtCar.Text);            
            w.WriteEndElement();
            w.WriteStartElement("Bonificadores");
            w.WriteElementString(txtBonFue.Tag.ToString(), txtBonFue.Text);
            w.WriteElementString(txtBonDes.Tag.ToString(), txtBonDes.Text);
            w.WriteElementString(txtBonCon.Tag.ToString(), txtBonCon.Text);
            w.WriteElementString(txtBonInt.Tag.ToString(), txtBonInt.Text);
            w.WriteElementString(txtBonSab.Tag.ToString(), txtBonSab.Text);     
            w.WriteElementString(txtBonCar.Tag.ToString(), txtBonCar.Text);
            w.WriteEndElement();
            w.WriteEndElement();
            w.Close();
            MessageBox.Show("El fichero ha sido guardado.");
        }
        //private void leerXML()
        //{
        //    string path = @".\Recursos\DB\PJ\";
        //    this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

        //    openFileDialog1.InitialDirectory = path;
        //    openFileDialog1.Title = "Browse XML Files";
        //    openFileDialog1.DefaultExt = "xml";
        //    openFileDialog1.ShowDialog();
        //    string filename = openFileDialog1.SafeFileName;
        //    string ruta = Path.Combine(path, filename);
        //    XDocument pj = XDocument.Load(ruta);
        //    XElement infoPersonaje = pj.Element("Personaje");
        //    IEnumerable<XElement> infoRasgos = infoPersonaje.Descendants("Rasgos");
        //    foreach (XElement datos in infoRasgos)
        //    {
        //        txtName.Text = datos.Element("Nombre").Value;
        //        cbClase.Text = datos.Element("Clase").Value;
        //        cbRaza.Text = datos.Element("Raza").Value;
        //    }
        //    IEnumerable<XElement> infoAtributos = infoPersonaje.Descendants("Atributos");
        //    foreach (XElement datos in infoAtributos)
        //    {
        //        txtFue.Text = datos.Element("Fuerza").Value;
        //        txtCar.Text = datos.Element("Carisma").Value;
        //        txtCon.Text = datos.Element("Constitución").Value;
        //        txtSab.Text = datos.Element("Sabiduria").Value;
        //        txtInt.Text = datos.Element("Inteligencia").Value;
        //        txtDes.Text = datos.Element("Destreza").Value;
        //    }
        //    IEnumerable<XElement> infoBonificadores = infoPersonaje.Descendants("Bonificadores");
        //    foreach (XElement datos in infoBonificadores)
        //    {
        //        txtBonFue.Text = datos.Element("BonFue").Value;
        //        txtBonCar.Text = datos.Element("BonCar").Value;
        //        txtBonCon.Text = datos.Element("BonCon").Value;
        //        txtBonSab.Text = datos.Element("BonSab").Value;
        //        txtBonInt.Text = datos.Element("BonInt").Value;
        //        txtBonDes.Text = datos.Element("BonDes").Value;
        //    }
        //}
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @".\Recursos\DB\PJ\";
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.Title = "Browse XML Files";
                openFileDialog1.DefaultExt = "xml";
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.SafeFileName;
                string ruta = Path.Combine(path, filename);
                List<TextBox> listaTextBox = CrearLista();
                
                Cargar carga = new Cargar();
                carga.CargarDatos(listaTextBox, ruta, cbClase, cbRaza);
                //leerXML();
                btnTirada.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede cargar");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cmdMax.Visible = false;
            cmdMin.Visible = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnBar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            cmdMin.Visible = false;
            cmdMax.Visible = true;
        }
        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

      
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


