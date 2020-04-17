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
            try
            {
                InitializeComponent();
                Contaner.Children.Clear();
                Loader loader = new Loader();
                BuildInformation[] buildInformation = loader.Deserialize();
                for (int i = 0; i < buildInformation.Length; i++)
                {
                    Element element = new Element();
                    element.Index = buildInformation[i].index;
                    element.button = new ButtonWithIndex();
                    element.button.Content = "Close";
                    element.button.Click += DeleteTodo;
                    element.checkBox = new CheckBoxWithIndex();
                    element.checkBox.Content = buildInformation[i].text;
                    element.checkBox.IsChecked = buildInformation[i].isChecked;
                    element.MakeEqualIndex();
                    if (buildInformation[i].isChecked == true)
                    {
                        CheckBoxManager checkBoxManager = new CheckBoxManager();
                        CheckBox checkBox = element.checkBox;
                        checkBoxManager.CrossOut(ref checkBox);
                    }
                    element.checkBox.Checked += Check;
                    element.checkBox.Unchecked += Uncheck;
                    GridCreator creator = new GridCreator();
                    Grid grid = creator.CreateTODOGrid(element);
                    elements.Add(element);
                    Contaner.Children.Add(grid);
                }
            }
            catch
            {

            }
        }

        private void TBAddTodo(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    AddTodo();
                }
            }
            catch
            {

            }
        }

        private void DeleteTodo(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonWithIndex button = (ButtonWithIndex)sender;
                elements.RemoveAt(button.index);
                Contaner.Children.RemoveAt(button.index);
                UpdateIndexes();
            }
            catch
            {

            }
        }

        private void BtnAddTodo(object sender, RoutedEventArgs e)
        {
            AddTodo();
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            try
            {
                elements.Clear();
                Contaner.Children.Clear();
            }
            catch
            {

            }
        }

        private void ChangeSelectionType(object sender, RoutedEventArgs e)
        {
            try
            {
                RoundTypeOfSelectionChanger changer = new RoundTypeOfSelectionChanger();
                changer.Change(ref typeOfSelection);
                Selector.Content = typeOfSelection.ToString();
                RenderTodos();
            }
            catch
            {

            }
        }

        private void AddTodo()
        {
            try
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
            catch
            {

            }
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBoxWithIndex)sender;
                CheckBoxManager checkBoxManager = new CheckBoxManager();
                checkBoxManager.CrossOut(ref checkBox);
                RenderTodos();
            }
            catch
            {

            }
        }

        private void Uncheck(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBoxWithIndex)sender;
                CheckBoxManager checkBoxManager = new CheckBoxManager();
                checkBoxManager.ReCrossOut(ref checkBox);
                RenderTodos();
            }
            catch
            {

            }
        }

        void RenderTodos()
        {
            try
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
            catch
            {

            }
        }

        void UpdateIndexes()
        {
            try
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    elements[i].Index = i;
                    elements[i].MakeEqualIndex();
                }
            }
            catch
            {

            }
        }

        private void SaveInfoBeforeClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Saver saver = new Saver();
                Convertor convertor = new Convertor();
                BuildInformation[] information = new BuildInformation[elements.Count];
                for (int i = 0; i < information.Length; i++)
                {
                    TextBlock textBlock = new TextBlock();

                    if (typeof(TextBlock) == elements[i].checkBox.Content.GetType())
                    {
                        textBlock = (TextBlock)elements[i].checkBox.Content;
                    }
                    else if (typeof(string) == elements[i].checkBox.Content.GetType())
                    {
                        textBlock.Text = (string)elements[i].checkBox.Content;
                    }

                    elements[i].checkBox.Content = textBlock.Text;

                    information[i] = convertor.ConvertFromElementToBuildInformation(elements[i]);
                }
                saver.Serialize(information);
            }
            catch
            {

            }
        }
    }
}