namespace BottomSheet.Components.Drawers;

public partial class ListDrawer : ContentView
{
	public ListDrawer(int sizeList)
	{
		InitializeComponent();

		for (var i = 0; i < sizeList; i++)
		{
			pgList.Add(new Label() { BackgroundColor = Colors.AliceBlue, Text = "Value " + i, FontSize = 14, Padding = 10 });
		}
	}

	

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		BottomSheet.Close();
    }
}
