//using System.Web.Http;
using System.Xml;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    // Controlador de la API
    public class ControllerXml : ControllerBase
    {
        [HttpGet]
        [Route("api/xml")]
        public OkObjectResult GetXMLInfo()
        {
            // Leer el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\alexx\\source\\repos\\API\\ArchivoXML\\XmlDoc.xml");

            // Crear una instancia del modelo
            XMLModel model = new XMLModel();

            // Asignar los valores de los nodos del XML al modelo
            //model.Nombre = xmlDoc.SelectSingleNode("/Persona/Nombre").InnerText;
            model.Nombre = xmlDoc.SelectSingleNode("/Persona/Nombre").OuterXml;
            model.name = xmlDoc.SelectSingleNode("/Persona/Nombre").Attributes["name"].Value;
            model.Edad = int.Parse(xmlDoc.SelectSingleNode("/Persona/Edad").InnerText);
            model.Direccion = xmlDoc.SelectSingleNode("/Persona/Direccion").InnerText;

            // Convertir el modelo a JSON
            string json = JsonConvert.SerializeObject(model);

            // Devolver la respuesta en formato JSON
            return new OkObjectResult(json);
        }
    }
}
