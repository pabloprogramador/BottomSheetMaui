using System;
using BottomSheet.Components.Drawers;

namespace BottomSheet
{
    class BottomSheet
    {
        public static Task<T> Open<T>(View view) where T : new()
        {
            return Popup.Open<T>(new Drawer(view));
        }

        public static Task<string> Open(View view)
        {
            return Popup.Open(new Drawer(view));
        }

        public static Task Close(object returnValue = null)
        {
            return Popup.Close(returnValue);
        }
    }
}