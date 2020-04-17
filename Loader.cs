using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TODO
{
    class Loader
    {
        public BuildInformation[] Deserialize()
        {
            BuildInformation[] buildInformation = new BuildInformation[0];
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BuildInformation[]));
                using (FileStream fs = new FileStream("todosList.xml", FileMode.Open))
                {
                    buildInformation = (BuildInformation[])xmlSerializer.Deserialize(fs);
                }
            }
            catch
            {

            }
            return buildInformation;
        }
    }
}
