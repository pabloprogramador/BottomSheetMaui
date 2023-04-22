namespace BottomSheet.Components.Drawers;

public partial class ListDrawer : BaseDrawer
{
	public ListDrawer()
	{
		InitializeComponent();
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		Close();
    }
}
