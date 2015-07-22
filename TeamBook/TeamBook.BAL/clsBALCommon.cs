using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TeamBook.BAL
{
    public class clsBALCommon:IDisposable
    {
        public void Dispose()
        { }
        public static string ConvertToXMLGeneric<T>(List<T> objData)
        {
            string xmlResult = "";
            if (objData != null)
            {
                StringWriter Swriter = new StringWriter();
                XmlSerializer XSerializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("ObjData"));
                XmlSerializerNamespaces xNamespace = new XmlSerializerNamespaces();
                xNamespace.Add("", "");
                XmlWriterSettings xSettings = new XmlWriterSettings();
                xSettings.OmitXmlDeclaration = true;
                xSettings.Indent = true;
                xSettings.Encoding = System.Text.Encoding.Default;
                XmlWriter xwriter = XmlWriter.Create(Swriter, xSettings);
                XSerializer.Serialize(Swriter, objData, xNamespace);
                xmlResult = Swriter.ToString();
                xSettings = null;
                Swriter.Flush();

            }
            return xmlResult;
        }
    }
}
