using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace BottomSheet.Components.Drawers;

public partial class CustomDrawer : Grid
{
    public double BackgroundOpacity { get; set; } = .4;
    public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(
            nameof(IsOpen),
            typeof(bool),
            typeof(CustomDrawer),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: IsOpenPropertyChanged);

    private static void IsOpenPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomDrawer)bindable;

        if ((bool)newValue)
        {
            control.Open();
        }
        else
        {
            control.Close();
        }
    }

    public bool IsOpen
    {
        get { return (bool)base.GetValue(IsOpenProperty); }
        set { base.SetValue(IsOpenProperty, value); }
    }

    double screenWidth;
    double screenHeight;
    double y;
    double headHeight = 280;
    double minFree = 40;
    bool isFull = false;
    bool isfirst = true;

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        screenWidth = width;
        screenHeight = height;
        isfirst = false;
        if (IsOpen)
            Open();
    }



    public CustomDrawer()
    {
        InitializeComponent();
        this.IsVisible = false;
    }

    protected async override void OnParentChanged()
    {
        base.OnParentChanged();
        var cache = this.Children.Last();
        this.Remove(this.Children.Last());
        this.pgContent.Add(cache);

    }

    async private void Open()
    {

        pgBottomSheet.CancelAnimations();
        pgBottomSheet.TranslationY = screenHeight + 50;
        pgBackground.Opacity = 0;
        this.IsVisible = true;
        if (isfirst) return;

#if ANDROID
        await Task.Delay(100);
#endif
        double height = screenHeight - Math.Max(pgContentScroll.Height + 32, headHeight);
        height = Math.Max(height, 0);

        if (height == 0)
        {
            pgContentScroll.HeightRequest = screenHeight;
            pgContentScroll.ScrollToAsync(0, 0, false);
        }

        pgBackground.FadeTo(BackgroundOpacity, 500);

        await pgBottomSheet.TranslateTo(0, height, 500, Easing.CubicOut);
        if (height == 0)
        {
            pgBottomSheetBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0, 0, 0, 0)
            };
        }
    }

    async private void Close()
    {
        pgBottomSheet.CancelAnimations();
        pgBottomSheetBorder.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(24, 24, 0, 0)
        };
        pgBackground.FadeTo(0, 500);
        await pgBottomSheet.TranslateTo(0, screenHeight + 50, 500, Easing.CubicOut);
        this.IsVisible = false;
    }




    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        IsOpen = false;
    }

    void PanGestureRecognizer_PanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Running:

                pgBottomSheet.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(pgBottomSheet.Height - screenHeight));
                break;

            case GestureStatus.Completed:
                y = pgBottomSheet.TranslationY;
                break;
        }
    }

    void pgBackground_Clicked(System.Object sender, System.EventArgs e)
    {
        IsOpen = false;
    }
}