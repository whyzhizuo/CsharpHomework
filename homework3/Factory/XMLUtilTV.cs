using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Factory
{
    class XMLUtilTV
    {
        public static List<string> ParseTVXML(string path)
        {
            List<string> brandNameList = new List<string>();

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);

                XmlNodeList brandList = xmlDocument.GetElementsByTagName("brandName");
                foreach (XmlNode node in brandList)
                {
                    Console.Write(node.Name);
                    brandNameList.Add(node.InnerText);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error :" + e.Message );
            }

            return brandNameList;
            
        }
    }
}
