namespace BottomSheet;
using Components.Drawers;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    
    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(new Components.Drawers.ListDrawer(3));
    }

    void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(new Components.Drawers.ListDrawer(11));
    }

    void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(new Components.Drawers.ListDrawer(30));
    }
}


