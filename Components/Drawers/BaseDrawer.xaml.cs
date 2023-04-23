using Microsoft.Maui.Controls.Shapes;

namespace BottomSheet.Components.Drawers;

public partial class BaseDrawer : Popup
{
    public BaseDrawer(DrawerView view)
    {
        InitializeComponent();
        this.IsVisible = false;
        pgContentView.Add(view);
        view.CallBackReturn = new Command((object obj) => {
            CloseBottomSheet(obj);
        });
    }

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


    public async void Open()
    {
        pgBottomSheet.CancelAnimations();
        pgBottomSheet.TranslationY = screenHeight + 50;
        this.IsVisible = true;
        if (isFirst) return;

        while (pgContentScroll.Height < 0)
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

        await pgBottomSheet.TranslateTo(0, height, 500, Easing.CubicOut);
        if (height == 0)
        {
            pgBottomSheetBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0, 0, 0, 0)
            };
        }
    }

    public async Task CloseBottomSheet(object obj = null)
    {
        pgBottomSheet.CancelAnimations();
        pgBottomSheetBorder.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(24, 24, 0, 0)
        };

        Close(obj);
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
        CloseBottomSheet();
    }
}
