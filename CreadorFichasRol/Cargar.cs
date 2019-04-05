using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CreadorFichasRol
{
    class Cargar
    {
        public void CargarDatos(IList<TextBox> listDatos, string filename)
        {
            XDocument pj = XDocument.Load(filename);
            XElement infoPersonaje = pj.Element("Personaje");
            IEnumerable<XElement> infoRasgos = infoPersonaje.Descendants("Rasgos");
            foreach (XElement datos in infoRasgos)
            {
                listDatos.Cast<TextBox>().Where(c => c.Name == "txtName");
            //    txtName.Text = datos.Element("Nombre").Value;
            //    cbClase.Text = datos.Element("Clase").Value;
            //    cbRaza.Text = datos.Element("Raza").Value;
            //}
            //IEnumerable<XElement> infoAtributos = infoPersonaje.Descendants("Atributos");
            //foreach (XElement datos in infoAtributos)
            //{
            //    txtFue.Text = datos.Element("Fuerza").Value;
            //    txtCar.Text = datos.Element("Carisma").Value;
            //    txtCon.Text = datos.Element("Constitución").Value;
            //    txtSab.Text = datos.Element("Sabiduria").Value;
            //    txtInt.Text = datos.Element("Inteligencia").Value;
            //    txtDes.Text = datos.Element("Destreza").Value;
            //}
            //IEnumerable<XElement> infoBonificadores = infoPersonaje.Descendants("Bonificadores");
            //foreach (XElement datos in infoBonificadores)
            //{
            //    txtBonFue.Text = datos.Element("BonFue").Value;
            //    txtBonCar.Text = datos.Element("BonCar").Value;
            //    txtBonCon.Text = datos.Element("BonCon").Value;
            //    txtBonSab.Text = datos.Element("BonSab").Value;
            //    txtBonInt.Text = datos.Element("BonInt").Value;
            //    txtBonDes.Text = datos.Element("BonDes").Value;
            }
        }


    }
}
