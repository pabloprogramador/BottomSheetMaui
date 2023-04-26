namespace BottomSheet;

public partial class SamplePopup : Popup
{
	public SamplePopup()
	{
		InitializeComponent();
        pgRoot.Scale = .1;
        pgRoot.Opacity = 0;
    }

    public async override Task AfterOpen()
    {
        base.AfterOpen();
        pgRoot.FadeTo(1, 200);
        await pgRoot.ScaleTo(1, 500, Easing.SpringOut);
    }
    

    public async override Task BeforeClose()
    {
        pgRoot.CancelAnimations();
        pgRoot.FadeTo(0, 300);
        await pgRoot.ScaleTo(.1, 300, Easing.SpringIn);
        await base.BeforeClose();
    }



    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Popup.Close();
    }

    

}
