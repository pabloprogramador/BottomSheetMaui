using System;
using BottomSheet.Components.Drawers;

namespace BottomSheet
{

    public class Popup : ContentPage
    {
        public Popup()
        {
            this.BackgroundColor = Color.FromArgb("#01000000");
        }

        private ImageButton BackgroundBack;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BackgroundBack.FadeTo(.4, 500);

        }

        protected override void OnParentChanged()
        {

            base.OnParentChanged();
            var cache = this.Content;
            BackgroundBack = new ImageButton() { BackgroundColor = Colors.Black, Opacity = 0 };
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

        public async virtual Task BeforeClose()
        {
            //max delay 400
        }

        public async virtual Task AfterClose()
        {
            
        }

        public static async Task<T> Open<T>(Popup page) where T : new()
        {
            try
            {
                if (Application.Current?.MainPage != null)
                    await Application.Current.MainPage.Navigation.PushModalAsync(page, false);

                return (T)await page.CallBackResult.Task;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static async Task<string> Open(Popup page)
        {
            try
            {
                if (Application.Current?.MainPage != null)
                    await Application.Current.MainPage.Navigation.PushModalAsync(page, false);

                return (string)await page.CallBackResult.Task;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static async Task Close(object returnValue = null)
        {
            if (Application.Current?.MainPage != null && Application.Current.MainPage.Navigation.ModalStack.Count > 0)
            {

                Popup currentPage = (Popup)Application.Current.MainPage.Navigation.ModalStack.LastOrDefault();

                currentPage.BeforeClose();
                await currentPage.BackgroundBack.FadeTo(0, 400);

                currentPage?.CallBackResult.TrySetResult(returnValue);
                await Application.Current.MainPage.Navigation.PopModalAsync(false);

                await currentPage.AfterClose();
            }
        }
    }
}