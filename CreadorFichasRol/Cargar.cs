using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CreadorFichasRol
{
    class Cargar
    {
        /// <summary>
        /// anadir aqui un bucle que deje los textbox cargados en enabled para que no peudan ser modificados con trampita.
        /// 
        /// </summary>
        /// <param name="listDatos"></param>
        /// <param name="filename"></param>
        /// <param name="clase"></param>
        /// <param name="raza"></param>
        public void CargarDatos(List<TextBox> listDatos, string filename, ComboBox clase, ComboBox raza)
        {
            XDocument pj = XDocument.Load(filename);
            XElement infoPersonaje = pj.Element("Personaje");
            IEnumerable<XElement> infoRasgos = infoPersonaje.Descendants("Rasgos");
            foreach (XElement datos in infoRasgos)
            {            
                listDatos[listDatos.FindIndex(x => x.Tag == "Nombre")].Text = datos.Element("Nombre").Value;
                clase.Text = datos.Element("Clase").Value;
                raza.Text = datos.Element("Raza").Value;
            }
            IEnumerable<XElement> infoAtributos = infoPersonaje.Descendants("Atributos");
            foreach (XElement datosAtt in infoAtributos)
            {
                listDatos[listDatos.FindIndex(x => x.Tag == "Fuerza")].Text = datosAtt.Element("Fuerza").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "Carisma")].Text = datosAtt.Element("Carisma").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "Constitución")].Text = datosAtt.Element("Constitución").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "Sabiduria")].Text = datosAtt.Element("Sabiduria").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "Inteligencia")].Text = datosAtt.Element("Inteligencia").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "Destreza")].Text = datosAtt.Element("Destreza").Value;
            }
            IEnumerable<XElement> infoBonificadores = infoPersonaje.Descendants("Bonificadores");
            foreach (XElement datosBon in infoBonificadores)
            {
                listDatos[listDatos.FindIndex(x => x.Tag == "BonFue")].Text = datosBon.Element("BonFue").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "BonCar")].Text = datosBon.Element("BonCar").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "BonCon")].Text = datosBon.Element("BonCon").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "BonSab")].Text = datosBon.Element("BonSab").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "BonInt")].Text = datosBon.Element("BonInt").Value;
                listDatos[listDatos.FindIndex(x => x.Tag == "BonDes")].Text = datosBon.Element("BonDes").Value;
            }
        }
    }
}
