namespace BottomSheet.Components.Drawers;

public partial class Drawer : Popup
{
	public Drawer(View view)
	{
		InitializeComponent();
		pgContentView.Add(view);
	}
}
