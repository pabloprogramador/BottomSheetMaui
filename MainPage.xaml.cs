namespace BottomSheet;
using Components.Drawers;

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
        Drawer.Open(drawer1);
        Drawer.Open(drawer2);
    }

    void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(drawer2);
    }

    void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        Drawer.Open(drawer3);
    }
}


