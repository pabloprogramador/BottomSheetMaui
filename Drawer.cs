using System;
using BottomSheet.Components.Drawers;

namespace BottomSheet
{
	public class Drawer
	{
        public static Task<T> Open<T>(DrawerView view) where T : new()
        {
            return Popup.Open<T>(new BaseDrawer(view));
        }

        public static Task<string> Open(DrawerView view)
        {
            return Popup.Open(new BaseDrawer(view));
        }

        public static Task Close(object returnValue = null)
        {
            return Popup.Close(returnValue);
        }
    }
}

