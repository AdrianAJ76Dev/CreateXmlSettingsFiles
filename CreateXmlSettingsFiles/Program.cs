using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CreateXmlSettingsFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Documents Folder {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.ReadLine();

            CreateSSLSettings();
        }

        static void CreateSSLSettings()
        {
            XElement SSLSettings =
                new XElement("Settings_SSL",
                    new XElement("Dev_Machine",
                        new XAttribute("Machine_Name", "Motown-Mobile-v"),
                        new XElement("TemplatePath", @"C:\Users\Adria\Documents\Dev Projects\SSL\Documents\"),
                        new XElement("DocumentPath", @"C:\Users\Adria\Documents\Dev Projects\SSL\Documents\"),
                        new XElement("Path", @"C:\Users\Adria\Documents\Dev Projects\SSL\Documents\"),
                        new XElement("XmlPath", @"C:\Users\Adria\Documents\Dev Projects\SSL\Documents\")
                        ),

                    new XElement("Dev_Machine",
                        new XAttribute("Machine_Name", "PF00ZJG5"),
                        new XElement("TemplatePath", @"C:\Users\ajones\Documents\Automation\Code\Word\SSL Work\"),
                        new XElement("DocumentPath", @"C:\Users\ajones\Documents\Automation\Code\Word\SSL Work\"),
                        new XElement("Path", @"C:\Users\ajones\Documents\Automation\Code\Word\SSL Work\"),
                        new XElement("XmlPath",@"C:\Users\ajones\Documents\Automation\Code\Word\SSL Work\")
                        ),

                    new XElement("TemplateName", "Sole Source Letter v6.dotx"),
                    new XElement("DocumentName", "CB Sole Source Letter.docx"),
                    new XElement("Xmlfilename", "SSL.xml")
                );

            Console.WriteLine("This Machine is {0}", Environment.MachineName);
            Console.WriteLine();

            string settingsfilepath = string.Empty;
            foreach (XElement el in SSLSettings.Elements("Dev_Machine"))
            {
                Console.WriteLine("Looking at Machine: {0}", el.Attribute("Machine_Name").Value);
                if (el.Attribute("Machine_Name").Value.ToLower() == Environment.MachineName.ToLower())
                {
                    settingsfilepath = el.Element("XmlPath").Value + SSLSettings.Element("Xmlfilename").Value;
                    Console.WriteLine("This Element Value is {0}",el.Value);
                }
            }

            // Using Linq
            Console.WriteLine("{0}", Environment.MachineName.ToString());
            var dev_machine = from el in SSLSettings.Elements("Dev_Machine")
                                                where el.Attribute("Machine_Name").Value == Environment.MachineName.ToString()
                                                select el;


            //SSLSettings.Save(dev_machine.Element("DocumentPath").Value + dev_machine.Element("DocumentName"));

            Console.WriteLine("Saved Xml file");
            Console.Read();
        }
    }
}
