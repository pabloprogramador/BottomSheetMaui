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
        Drawer.Open(new Components.Drawers.ListDrawer());
    }

    void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
       
    }

    void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
       
    }
}


