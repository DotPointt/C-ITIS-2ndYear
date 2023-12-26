using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyGame.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string _greeting = "Добро пожаловать в Уно!";

    public string Greeting { 
        get => _greeting;
        set
        {
            _greeting = value;
            OnPropertyChanged();
        }
    }
        

    public MainViewModel()
    {
        Task.Run(async () => 
        {
            await Task.Delay(5000);
            Greeting = "New Greeting";
        });
    }

}
