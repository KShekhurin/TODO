using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO
{
    class Convertor
    {
        public BuildInformation ConvertFromElementToBuildInformation(Element element)
        {
            BuildInformation buildInformation = new BuildInformation(element.checkBox.IsChecked, (string)element.checkBox.Content, element.Index);
           
            return buildInformation;
        }
    }
}
