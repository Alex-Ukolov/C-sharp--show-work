using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;


namespace _1practicheskaya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;

        public MainWindow()
        {
            InitializeComponent();
            DataGridCollection = CollectionViewSource.GetDefaultView(TestData);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            
        }

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; NotifyPropertyChanged("DataGridCollection"); }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as TestClass;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return data.product.Contains(_filterString);
                }
                return true;
            }
            return false;
        }

        public IEnumerable<TestClass> TestData
        {
            get
            {
                yield return new TestClass { product = "11", name = "milk" ,cost= "30 ",uniq="1" };
                yield return new TestClass { product = "12", name = "bananas", cost = "40", uniq = "1" };
                yield return new TestClass { product = "13", name = "meat horse", cost = "50", uniq = "1" };
                yield return new TestClass { product = "14", name = "meat spoke" , cost = "60", uniq = "1" };
                yield return new TestClass { product = "15", name = "fish", cost = "70", uniq = "1" };
                yield return new TestClass { product = "16", name = "orange", cost = "80", uniq = "1" };
                yield return new TestClass { product = "17", name = "potatoes", cost = "90", uniq = "1" };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }


    public class TestClass
    {
        public string product { get; set; }
        public string name { get; set; }
        public string cost { get; set; }
        public string uniq { get; set; }
    }
}
