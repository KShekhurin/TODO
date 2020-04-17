using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO
{
    class Element
    {
        public ButtonWithIndex button;
        public CheckBoxWithIndex checkBox;

        public bool visible = true;

        public int Index { get; set; }

        public Element(int index, ButtonWithIndex button, CheckBoxWithIndex checkBox)
        {
            Index = index;
            this.button = button;
            this.checkBox = checkBox;
            button.index = index;
            checkBox.index = index;
        }

        public Element()
        {

        }

        public void MakeEqualIndex()
        {
            button.index = Index;
            checkBox.index = Index;
        }
    }
}
