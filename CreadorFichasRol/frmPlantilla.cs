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
            XmlWriter w = XmlWriter.Create("PJ_" + txtName.Text + ".xml");
            w.WriteStartElement("PJ_" + txtName.Text);
            w.WriteElementString(txtName.Tag.ToString(), txtName.Text);
            w.WriteElementString(cbClase.Tag.ToString(), cbClase.Text);
            w.WriteElementString(cbRaza.Tag.ToString(), cbRaza.Text);
            w.WriteElementString(txtDes.Name, txtDes.Text);
            w.WriteElementString(txtFue.Name, txtFue.Text);
            w.WriteElementString(txtInt.Name, txtInt.Text);
            w.WriteElementString(txtSab.Name, txtSab.Text);
            w.WriteElementString(txtCar.Name, txtCar.Text);
            w.WriteElementString(txtCon.Name, txtCon.Text);
            w.WriteElementString(txtBonFue.Name, txtBonFue.Text);
            w.WriteElementString(txtBonSab.Name, txtBonSab.Text);
            w.WriteElementString(txtBonCon.Name, txtBonCon.Text);
            w.WriteElementString(txtBonDes.Name, txtBonDes.Text);
            w.WriteElementString(txtBonCar.Name, txtBonCar.Text);
            w.WriteElementString(txtBonInt.Name, txtBonDes.Text);
            w.WriteEndElement();
            w.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnMin.Visible = true;
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
            btnMin.Visible = false;
            btnMax.Visible = true;
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
