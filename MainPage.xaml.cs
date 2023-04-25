namespace BottomSheet;
using Components.Drawers;
using Components.Lists;
//using CoreGraphics;
using Microsoft.Maui.Controls;

//using UIKit;


public partial class MainPage : ContentPage
{
    int count = 0;
    ListDrawer drawer1 = new ListDrawer(3);
    ListDrawer drawer2 = new ListDrawer(11);
    ListDrawer drawer3 = new ListDrawer(30);

    public MainPage()
    {
        InitializeComponent();
    }

    async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        //Popup.Open(new lixoPage());
        Drawer.Open(new SimpleList());
    }

    async void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
       string teste = await Drawer.Open(drawer2);
        System.Diagnostics.Debug.WriteLine(teste);
    }

   async void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        string teste = await Drawer.Open(drawer3);
        System.Diagnostics.Debug.WriteLine(teste);
    }
}


