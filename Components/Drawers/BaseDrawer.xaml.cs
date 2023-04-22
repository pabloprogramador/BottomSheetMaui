using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace BottomSheet.Components.Drawers;

public partial class BaseDrawer : Grid
{
    public double BackgroundOpacity = .4;
    
    bool isFirstCache;
    double sizeScroll;
    double screenWidth;
    double screenHeight;
    double y;
    double headHeight = 280;
    double minFree = 40;
    bool isFull = false;
    bool isFirst = true;

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        screenWidth = width;
        screenHeight = height;
        isFirst = false;
        Open();
    }

    public BaseDrawer()
    {
        InitializeComponent();
        this.IsVisible = false;
    }

    protected async override void OnParentChanged()
    {
        base.OnParentChanged();
        
        if (isFirstCache) return; isFirstCache = true;
        var cache = this.Children.Last();
        this.Remove(this.Children.Last());
        this.pgContent.Add(cache);

    }

    public async void Open()
    {
        pgBottomSheet.CancelAnimations();
        pgBottomSheet.TranslationY = screenHeight + 50;
        pgBackground.Opacity = 0;
        this.IsVisible = true;
        if (isFirst) return;

        while(pgContentScroll.Height < 0)
        {
            await Task.Delay(100);
        }

        sizeScroll = pgContentScroll.Height;
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

    public async Task Close()
    {
        pgBottomSheet.CancelAnimations();
        pgBottomSheetBorder.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(24, 24, 0, 0)
        };
        pgBackground.FadeTo(0, 500);
        await pgBottomSheet.TranslateTo(0, screenHeight + 50, 500, Easing.CubicOut);
        pgContentScroll.HeightRequest = sizeScroll;
        this.IsVisible = false;
    }


    public void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Open();
    }

    public void PanGestureRecognizer_PanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
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

    public void pgBackground_Clicked(System.Object sender, System.EventArgs e)
    {
        Close();
    }  
}