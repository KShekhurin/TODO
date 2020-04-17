using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TODO
{
    class Saver
    {
        public void Serialize(BuildInformation[] buildInformations)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildInformation[]));

            try
            {
                File.Delete(@"todosList.xml");
            }
            catch
            {

            }
            try
            {
                using (FileStream fs = new FileStream("todosList.xml", FileMode.CreateNew))
                {
                    serializer.Serialize(fs, buildInformations);
                }
            }
            catch
            {

            }
        }
    }
}
