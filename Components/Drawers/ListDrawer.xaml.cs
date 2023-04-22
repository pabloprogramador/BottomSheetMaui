namespace BottomSheet.Components.Drawers;

public partial class ListDrawer : BaseDrawer
{
	public ListDrawer(int sizeList)
	{
		InitializeComponent();

		for (var i = 0; i < sizeList; i++)
		{
			pgList.Add(new Label() { Text = "Value " + i, FontSize = 14, Padding = 10 });
		}
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Close();
    }
}
