﻿using System;
namespace BottomSheet.Components.Drawers
{
	public class LixoDrawer : Popup
	{
		public LixoDrawer()
		{
			Grid grid = new Grid();
			grid.BackgroundColor = Colors.AliceBlue;
			grid.HeightRequest = 200;
			grid.WidthRequest = 200;
			Content = grid;
			

        }

		public override Task BeforeClose()
		{
			return App.Current.MainPage.DisplayAlert("aa", "adf", "adf");
		}


	}
}

