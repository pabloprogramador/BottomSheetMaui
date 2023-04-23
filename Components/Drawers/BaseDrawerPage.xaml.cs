using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace BottomSheet.Components.Drawers;

public partial class BaseDrawerPage : Popup
{

    public TaskCompletionSource<object> returnResultTask = new();

    public BaseDrawerPage()
	{
        InitializeComponent();
     //   this.BackgroundColor = Color.FromArgb("#01000000");
    }

   // public bool IsCloseOnBackgroundClick { get; set; } = true;

    //protected override bool OnBackButtonPressed()
    //{
    //    if (!IsCloseOnBackgroundClick)
    //        return true;

    //    return base.OnBackButtonPressed();
    //}

   async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //if (IsCloseOnBackgroundClick)
        //    await BottomSheet.ClosePopup();
    }
}

