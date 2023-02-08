using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Microsoft.UI.Xaml.Controls;
using System.ComponentModel;
using Microsoft.UI.Xaml;

namespace WinUI3Test;

public sealed partial class MainWindow : Window
{
    ObservableCollection<TestClass> ListOfStrings = new();
    int count = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TestClass testClass = new()
        {
            Note = $"this is note number {count++}"
        };

        ListOfStrings.Add(testClass);
    }
    private void Expander_Expanding(Expander sender, ExpanderExpandingEventArgs args)
    {
        TestClass testClass = (TestClass)sender.DataContext;
        testClass.Expand = true;
    }
}

public class TestClass : INotifyPropertyChanged
{
    //Exclusevily used to keep track of the count of items in the ItemsRepeater
    public string Note { get; set; }
    public bool Expand
    {
        get => expand;
        set
        {
            if(value != expand)
            {
                expand = value;
                NotifyPropertyChanged();
            }
        }
    }
    private bool expand;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
