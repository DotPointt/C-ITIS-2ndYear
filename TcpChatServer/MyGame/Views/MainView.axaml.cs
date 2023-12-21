using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace MyGame.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void ButtonClicked(object source, RoutedEventArgs args)
    {
        Debug.WriteLine("Click!");
        StartButton.Content = "123123132213";
        GreetingBackground.IsVisible = false;

    }
}
