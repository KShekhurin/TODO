using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODO
{
    class CheckBoxManager
    {
        public void CrossOut(ref CheckBox checkBox)
        {
            TextBlock textBlock = new TextBlock();

            if (typeof(TextBlock) == checkBox.Content.GetType())
            {
                textBlock = (TextBlock)checkBox.Content;
            }
            else if (typeof(string) == checkBox.Content.GetType())
            {
                textBlock.Text = (string)checkBox.Content;
            }
            textBlock.TextDecorations = TextDecorations.Strikethrough;
            checkBox.Content = textBlock;
        }

        public void ReCrossOut(ref CheckBox checkBox)
        {
            TextBlock textBlock = new TextBlock();

            if (typeof(TextBlock) == checkBox.Content.GetType())
            {
                textBlock = (TextBlock)checkBox.Content;
            }
            else if (typeof(string) == checkBox.Content.GetType())
            {
                textBlock.Text = (string)checkBox.Content;
            }
            textBlock.TextDecorations = null;
            checkBox.Content = textBlock;
        }
    }
}
