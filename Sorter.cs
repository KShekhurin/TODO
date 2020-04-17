using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODO
{
    class Sorter
    {
        public void Sort(TypeOfSelection selection, ref List<Element> elements)
        {
            if (selection == TypeOfSelection.All)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].visible = true;
                }
            }
            else if (selection == TypeOfSelection.Checked)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].checkBox.IsChecked == true)
                    {
                        elements[i].visible = true;
                    }
                    else
                    {
                        elements[i].visible = false;
                    }
                }
            }
            else if (selection == TypeOfSelection.Unchecked)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].checkBox.IsChecked == false)
                    {
                        elements[i].visible = true;
                    }
                    else
                    {
                        elements[i].visible = false;
                    }
                }
            }
        }
    }
}
