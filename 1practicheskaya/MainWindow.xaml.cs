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
using System.ComponentModel;
using System.Data;

namespace _1practicheskaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = TestClass.getTestClass();
            TestClass st = rrr.SelectedItem as TestClass;
            string TestClasscost = Convert.ToString(st.cost);
            int b = Convert.ToInt32(st.cost);
            int c = 0;
            c +=b;
            lex.Text +=""+ c+",";
        }

        public class TestClass
        {
            
            public string product { get; set; }
            public string name { get; set; }
            public string cost { get; set; }
            public string uniq { get; set; }

            internal static IEnumerable<object> getTestClass()
            {
                yield return new TestClass { product = "11", name = "milk", cost = "30 ", uniq = "1" };
                yield return new TestClass { product = "12", name = "bananas", cost = "40", uniq = "1" };
                yield return new TestClass { product = "13", name = "meat horse", cost = "50", uniq = "1" };
                yield return new TestClass { product = "14", name = "meat spoke", cost = "60", uniq = "1" };
                yield return new TestClass { product = "15", name = "fish", cost = "70", uniq = "1" };
                yield return new TestClass { product = "16", name = "orange", cost = "80", uniq = "1" };
                yield return new TestClass { product = "17", name = "potatoes", cost = "90", uniq = "1" };
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rrr.ItemsSource = new List<TestClass>(new[] { new TestClass() { product = QQQ.Text, name = WWW.Text, cost = RRR.Text, uniq =TTT.Text } });

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string[] s = lex.Text.Split(',');
            int n, sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int.TryParse(s[i], out n);
                sum += n;
            }
            lexa.Text = "" + sum;
        }

        private void Button_Click55(object sender, RoutedEventArgs e)
        {
            rrr.ItemsSource =  null;
        }
    }
}

