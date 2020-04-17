using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO
{
    class RoundTypeOfSelectionChanger
    {
        public void Change(ref TypeOfSelection typeOfSelection)
        {
            if (typeOfSelection == TypeOfSelection.All)
            {
                typeOfSelection = TypeOfSelection.Checked;
            }
            else if (typeOfSelection == TypeOfSelection.Checked)
            {
                typeOfSelection = TypeOfSelection.Unchecked;
            }
            else if (typeOfSelection == TypeOfSelection.Unchecked)
            {
                typeOfSelection = TypeOfSelection.All;
            }
        }
    }
}
