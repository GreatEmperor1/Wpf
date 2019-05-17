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

namespace MyfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double min = 0;
        double max = 0;
        double s = 0;
        double f = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbX.Text);
            double b = double.Parse(tbB.Text);

            

            RadioButton radioButton = null;
            radioButton = GetCheckedRadioButton(radioButtons.Children, "func");
            //Calculate f(x)
            if (radioButton.Content.ToString() == "sin(x)")
            {
                f = Math.Sin(x);
            }
            else if (radioButton.Content.ToString() == "cos(x)")
            {
                f = Math.Cos(x);
            }
            else
            {
                f = Math.Tan(x);
            }
            //Calculate brunch result
            if (x * b > 1 && x * b < 10)
            {
                s = Math.Exp(f);
                tbResult.Text = "Brunch 1";
            }
            else if (x * b > 12 && x * b < 40)
            {
                s = Math.Sqrt(Math.Abs(f + 4 * b));
                tbResult.Text = "Brunch 2";
            }
            else
            {
                s = b * Math.Pow(f, 2);
                tbResult.Text = "Brunch 3";
            }

            if (s >= max)
            {
                if (min == 0)
                {
                    min = max;
                }
                max = s;
            }
            else if (min != 0 || s < max && s <= min)
            {
                min = s;
            }
            else
            {
                min = s;
            }

            if ((bool)(Min.IsChecked))
            {
                tbResult.Text += string.Format("\nMin = {0:0.000}", min);
            } else if ((bool)(Max.IsChecked))
            {
                tbResult.Text += string.Format("\nMax = {0:0.000}", max);
            }

            //tbResult.Text = "Lab1" + Environment.NewLine;
            tbResult.Text += string.Format("\ns = {0:0.000}", s);
        }

        private void TextBox_TextChanged_B(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_X(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_Result(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            //MessageBox.Show(pressed.Content.ToString());
        }

        private RadioButton GetCheckedRadioButton(UIElementCollection children, String groupName)
        {
            return children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true && rb.GroupName == groupName);
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Min.Content.ToString() + " отмечен");
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Min.Content.ToString() + " не отмечен");
        }

        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Min.Content.ToString() + " в неопределенном состоянии");
        }


    }
}
