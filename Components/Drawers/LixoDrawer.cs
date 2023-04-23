using System;
namespace BottomSheet.Components.Drawers
{
	public class LixoDrawer : BottomSheet
	{
		public LixoDrawer()
		{
			Grid grid = new Grid();
			grid.BackgroundColor = Colors.AliceBlue;
			grid.HeightRequest = 200;
			grid.WidthRequest = 200;
			Content = grid;
		}
	}
}

