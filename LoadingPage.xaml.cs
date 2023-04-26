namespace BottomSheet;

public partial class LoadingPage : Popup
{
	public LoadingPage()
	{
		InitializeComponent();
		IsCloseOnBackgroundClick = false;
		Init();
	}

	async void Init()
	{
		pgRoot.Opacity = 0;
		pgRoot.TranslationY = -200;

        await Task.Delay(3000);
        await Popup.Close();
    }

    public async override Task AfterOpen()
    {
        base.AfterOpen();
        pgRoot.FadeTo(1, 200);
        await pgRoot.TranslateTo(0 ,0, 500, Easing.SpringOut);
    }

    public async override Task BeforeClose()
    {
        this.CancelAnimations();
        this.FadeTo(0,300);
        pgRoot.TranslateTo(0, 200, 300, Easing.SpringIn);
        await base.BeforeClose();
    }
}
