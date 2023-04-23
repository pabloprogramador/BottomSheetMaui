namespace BottomSheet;
using Components.Drawers;
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
        //Drawer.Open(drawer1);
        //Drawer.Open(drawer2);
        //var contentView = new lixo();
        //var subview = new UIKit.UIView()
        //{
        //    Frame = new CGRect(0, 0, DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height),
        //    BackgroundColor = UIKit.UIColor.Red
        //};
        //subview.AddSubview(contentView.Content.  ToNative(MauiUIApplicationDelegate.Current));

        //MauiUIApplicationDelegate.Current.Window.RootViewController.View.AddSubview(subview);
        // await Application.Current.MainPage.Navigation.PushModalAsync(new lixoPage(),false);
        Popup.Open(new LixoDrawer());
    }

    void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        Popup.Open(new ListDrawerPage());
    }

    void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(drawer3);
    }
}


