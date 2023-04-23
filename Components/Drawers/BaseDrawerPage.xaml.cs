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

    public override Task BeforeClose()
    {
        return CloseTask();
    }


    private async Task CloseTask()
    {
        //var controlTemplate = this.ControlTemplate;
        //var contentPresenter = controlTemplate?.CreateContent() as ContentPresenter;

        // Defina a cor de fundo
        
        
        // Defina a cor de fundo
        //contentPresenter.Background = Colors.Red;
        //await contentPresenter?.ScaleTo(.5, 500);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var controlTemplate = this.ControlTemplate;
        var contentPresenter = controlTemplate?.CreateContent() as ContentPresenter;
        contentPresenter.Scale = .3;
    }
}

