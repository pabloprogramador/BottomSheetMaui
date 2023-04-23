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
    }

    

}

