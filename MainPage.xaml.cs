using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3Test;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        Loaded += delegate (object sender, RoutedEventArgs e)
        {
            Window window = App.MWindow;
            window.ExtendsContentIntoTitleBar = true;
            window.SetTitleBar(AppTitleBar);
        };
    }
}
