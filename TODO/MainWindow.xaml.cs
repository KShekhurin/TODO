using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TODO
{
    public partial class MainWindow : Window
    {
        List<Element> elements = new List<Element>();
        TypeOfSelection typeOfSelection = TypeOfSelection.All;

        public MainWindow()
        {
            InitializeComponent();
            Contaner.Children.Clear();
        }

        private void TBAddTodo(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddTodo();
            }

        }

        private void DeleteTodo(object sender, RoutedEventArgs e)
        {
            ButtonWithIndex button = (ButtonWithIndex)sender;
            elements.RemoveAt(button.index);
            Contaner.Children.RemoveAt(button.index);
            UpdateIndexes();
        }

        private void BtnAddTodo(object sender, RoutedEventArgs e)
        {
            AddTodo();
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            elements.Clear();
            Contaner.Children.Clear();
        }

        private void ChangeSelectionType(object sender, RoutedEventArgs e)
        {
            RoundTypeOfSelectionChanger changer = new RoundTypeOfSelectionChanger();
            changer.Change(ref typeOfSelection);
            Selector.Content = typeOfSelection.ToString();
            RenderTodos();
        }

        private void AddTodo()
        {
            if (Enterer.Text != "")
            {
                ButtonWithIndex button = new ButtonWithIndex();
                button.Content = "Close";
                button.Click += DeleteTodo;
                CheckBoxWithIndex checkBox = new CheckBoxWithIndex();
                checkBox.Content = Enterer.Text;
                checkBox.Checked += Check;
                checkBox.Unchecked += Uncheck;
                Element element = new Element(0, button, checkBox);
                GridCreator gridCreator = new GridCreator();
                elements.Insert(0, element);

                UpdateIndexes();

                Grid grid = gridCreator.CreateTODOGrid(element);
                Contaner.Children.Insert(0, grid);
                Enterer.Text = "";
                RenderTodos();
            }
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBoxWithIndex)sender;
            CheckBoxManager checkBoxManager = new CheckBoxManager();
            checkBoxManager.CrossOut(ref checkBox);
            RenderTodos();
        }

        private void Uncheck(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBoxWithIndex)sender;
            CheckBoxManager checkBoxManager = new CheckBoxManager();
            checkBoxManager.ReCrossOut(ref checkBox);
            RenderTodos();
        }

        void RenderTodos()
        {
            Sorter sorter = new Sorter();
            sorter.Sort(typeOfSelection, ref elements);
            Contaner.Children.Clear();
            GridCreator creator = new GridCreator();
            for (int i = 0; i < elements.Count; i++)
            {
                Grid grid = creator.CreateTODOGrid(elements[i]);
                if (elements[i].visible == false)
                {
                    grid.Visibility = Visibility.Collapsed;
                }
                Contaner.Children.Add(grid);
            }
        }

        void UpdateIndexes()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Index = i;
                elements[i].MakeEqualIndex();
            }
        }
    }
}