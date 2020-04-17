using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODO
{
    class GridCreator
    { 
        public Grid CreateTODOGrid(Element element)
        {
            Grid grid = new Grid();
            Button button = element.button;
            CheckBox checkBox = element.checkBox;

            ColumnDefinition columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            columnDefinition1.Width = new GridLength(1, GridUnitType.Auto);

            if (button.Parent != null)
            {
                var parent = (Panel)button.Parent;
                parent.Children.Remove(button);
            }
            if (checkBox.Parent != null)
            {
                var parent = (Panel)checkBox.Parent;
                parent.Children.Remove(checkBox);
            }

            grid.ColumnDefinitions.Add(columnDefinition);
            grid.ColumnDefinitions.Add(columnDefinition1);

            Grid.SetColumn(checkBox, 0);
            Grid.SetColumn(button, 1);


            grid.Children.Add(button);
            grid.Children.Add(checkBox);

            grid.Margin = new Thickness(3,3,3,0);

            return grid;
        }
    }
}
