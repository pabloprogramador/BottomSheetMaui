using System;
using BottomSheet.Components.Drawers;

namespace BottomSheet
{

    public class Popup : ContentPage
    {
        public bool IsFadeBackground = true;
        private ImageButton BackgroundBack;
        private static bool isBusy;

        public Popup()
        {
            this.BackgroundColor = Color.FromArgb("#01000000");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(IsFadeBackground)
            BackgroundBack.FadeTo(.4, 500);
        }

        protected override void OnParentChanged()
        {
            base.OnParentChanged();
            var cache = this.Content;
             BackgroundBack = new ImageButton() {
                BackgroundColor = IsFadeBackground ? Colors.Transparent : Colors.Black,
                Opacity = IsFadeBackground ? 1 : 0 };
            var bugdroid = new TapGestureRecognizer();
            cache.GestureRecognizers.Add(bugdroid);

            this.Content = new Grid() { BackgroundBack, cache };
            BackgroundBack.Clicked -= OnCloseBackgroundClicked;
            BackgroundBack.Clicked += OnCloseBackgroundClicked;
        }

        async void OnCloseBackgroundClicked(object sender, EventArgs args)
        {
            if (IsCloseOnBackgroundClick)
                Close();
        }

        public TaskCompletionSource<object> CallBackResult = new();

        public bool IsCloseOnBackgroundClick { get; set; } = true;

        protected override bool OnBackButtonPressed()
        {
            if (!IsCloseOnBackgroundClick)
                return true;

            Close();
            return true;
        }

        public async virtual Task BeforeOpen()
        {
            //max delay 500
        }

        public async virtual Task AfterOpen()
        {
            
        }

        public async virtual Task BeforeClose()
        {
            //max delay 400
        }

        public async virtual Task AfterClose()
        {

        }

        public static async Task<T> Open<T>(Popup page) where T : new()
        {
            if (isBusy) return default(T); isBusy = true;
            try
            {
                if (Application.Current?.MainPage != null)
                {
                    await page.BeforeOpen();
                    await Application.Current.MainPage.Navigation.PushModalAsync(page, false);
                    await page.AfterOpen();
                }

                return (T)await page.CallBackResult.Task;
            }
            catch (Exception ex)
            {
                isBusy = false;
                return default(T);
            }
        }

        public static async Task<string> Open(Popup page)
        {
            if (isBusy) return null; isBusy = true;
            try
            {
                if (Application.Current?.MainPage != null)
                {
                    await page.BeforeOpen();
                    await Application.Current.MainPage.Navigation.PushModalAsync(page, false);
                    await page.AfterOpen();
                }

                return (string)await page.CallBackResult.Task;
            }
            catch (Exception ex)
            {
                isBusy = false;
                return "";
            }

        }

        public static async Task Close(object returnValue = null)
        {
            if (Application.Current?.MainPage != null && Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {

                Popup currentPage = (Popup)Application.Current.MainPage.Navigation.ModalStack.LastOrDefault();

                await currentPage.BeforeClose();
                if (currentPage.IsFadeBackground)
                    await currentPage.BackgroundBack.FadeTo(0, 400);

                currentPage?.CallBackResult.TrySetResult(returnValue);
                await Application.Current.MainPage.Navigation.PopModalAsync(false);

                await currentPage.AfterClose();
                isBusy = false;
            }
        }
    }
}