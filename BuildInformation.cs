using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO
{
    [Serializable]
    public class BuildInformation
    {
        public bool? isChecked;
        public string text;
        public int index;

        public BuildInformation(bool? isChecked, string text, int index)
        {
            this.isChecked = isChecked;
            this.text = text;
            this.index = index;
        }
        public BuildInformation()
        {

        }
    }
}
