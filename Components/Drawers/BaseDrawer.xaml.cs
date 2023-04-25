using AndroidX.ConstraintLayout.Core;
using Microsoft.Maui.Controls.Shapes;

namespace BottomSheet.Components.Drawers;

public partial class BaseDrawer : Popup
{
    public BaseDrawer(DrawerView view)
    {
        InitializeComponent();
        pgContentView.Add(view);
        view.CallBackReturn = new Command((object obj) =>
        {
            CloseBottomSheet(obj);
        });
    }

    public double BackgroundOpacity = .4;

    bool isFirstCache;
    double sizeScroll;
    double screenWidth;
    double screenHeight;
    double y;
    double ypan;
    double headHeight = 280;
    double minFree = 70;
    bool isFull = false;
    bool isFirst = true;
    double baseY;

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
        if (isFirst) return;


        while (pgContentScroll.Height < 0)
        {
            await Task.Delay(100);
        }

        sizeScroll = pgContentScroll.Height;
        baseY = screenHeight - Math.Max(pgContentScroll.Height + 32, headHeight);
        baseY = Math.Max(baseY, 0);

        if (baseY == 0)
        {
            pgContentScroll.HeightRequest = screenHeight;
            pgContentScroll.ScrollToAsync(0, 0, false);
        }

        y = baseY;
        ypan = 0;
        pgBottomSheet.TranslateTo(0, baseY, 500, Easing.CubicOut);
        await Task.Delay(300);
        ChangeBorder(baseY == 0);
    }

    public async Task CloseBottomSheet(object obj = null)
    {
        pgBottomSheet.CancelAnimations();
        Close(obj);
        await pgBottomSheet.TranslateTo(0, screenHeight + 50, 500, Easing.CubicOut);
        y = pgBottomSheet.TranslationY;
        pgContentScroll.HeightRequest = sizeScroll;
    }


    private double startedY = 0;
    public async void PanGestureRecognizer_PanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
    {
        if (pgBottomSheet.AnimationIsRunning("TranslateTo")) return;

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // pgPanGesture.HeightRequest = screenHeight * 2;
                //pgPanGesture.TranslationY = 0;
                pgBottomSheet.CancelAnimations();
                startedY = pgBottomSheet.TranslationY;
                break;

            case GestureStatus.Running:
                System.Diagnostics.Debug.WriteLine(y +" :: "+e.TotalY+" :: "+e.GestureId);
                double aux = Math.Max(y + e.TotalY, 0);
                pgBottomSheet.TranslationY = aux;
                pgPanGesture.TranslationY = ypan - e.TotalY;
                ChangeBorder(pgBottomSheet.TranslationY == 0);
                break;

            case GestureStatus.Completed:
                //pgPanGesture.TranslationY = -400;
                pgPanGesture.TranslationY = ypan =  0;
                if (startedY == 0 && baseY > 0)
                {
                    if (pgBottomSheet.TranslationY - startedY < minFree)
                    {
                        pgBottomSheet.TranslateTo(0, 0, 100, Easing.CubicOut);
                        ChangeBorder(true);
                        y = 0;
                    }
                    else
                    {
                        await pgBottomSheet.TranslateTo(0, baseY, 300, Easing.CubicOut);
                        ChangeBorder(baseY == 0);
                        y = baseY;
                    }
                }
                else
                {
                    if (baseY == 0)
                    {
                        if (pgBottomSheet.TranslationY - startedY < minFree)
                        {
                            pgBottomSheet.TranslateTo(0, 0, 100, Easing.CubicOut);
                            ChangeBorder(true);
                            y = 0;
                        }
                        else
                        {
                            await CloseBottomSheet();
                        }
                    }
                    else
                    {
                        if (pgBottomSheet.TranslationY - baseY + (minFree * 2) < minFree)
                        {
                            pgBottomSheet.TranslateTo(0, 0, 300, Easing.CubicOut);
                            await Task.Delay(100);
                            ChangeBorder(true);
                            y = 0;
                        }
                        else
                        {

                            if (pgBottomSheet.TranslationY > baseY && Math.Abs(pgBottomSheet.TranslationY - baseY) > minFree)
                            {
                                await CloseBottomSheet();
                            }
                            else
                            {
                                await pgBottomSheet.TranslateTo(0, baseY, 100, Easing.CubicOut);
                                ChangeBorder(baseY == 0);
                                y = baseY;
                            }
                        }
                    }
                }
                break;
        }
    }

    public void pgBackground_Clicked(System.Object sender, System.EventArgs e)
    {
        CloseBottomSheet();
    }

    private void ChangeBorder(bool isZero)
    {

        if (isZero)
        {
            pgBottomSheetBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0, 0, 0, 0)
            };
        }
        else
        {
            pgBottomSheetBorder.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(24, 24, 0, 0)
            };
        }
    }

    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        pgPanGesture.IsVisible = false;
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        pgPanGesture.IsVisible = true;
    }
}
