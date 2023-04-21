namespace BottomSheet;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }



    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        pgDrawerSmart.IsOpen = true;
    }

    void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        pgDrawerNormal.IsOpen = true;
    }

    void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        pgDrawerBig.IsOpen = true;
    }
}


