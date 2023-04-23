namespace BottomSheet;

public partial class lixoPage : ContentPage
{
	public lixoPage()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromArgb("#01000000");
	}

   async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await Application.Current.MainPage.Navigation.PopModalAsync(false);
    }
}
