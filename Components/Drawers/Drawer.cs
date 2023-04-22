using System;
namespace BottomSheet.Components.Drawers
{
    public static class Drawer
    {
        private static BaseDrawer _view;
        private static Grid _root = new Grid();
        private static ContentPage _contentPage;
        private static View _cache;

        public async static void Open(BaseDrawer view)
        {
            _contentPage = (ContentPage)App.Current.MainPage.GetCurrentContentPage();
            if (_contentPage == null)
            {
                System.Diagnostics.Debug.WriteLine("#### DRAWER BOTTOMSHEET - NOT CONTENTPAGE FOUND");
                return;
            }

            _cache = _contentPage.Content;

            if (_cache != _root)
            {
                _contentPage.Content = _root;
                _root.Children.Add(_cache);
            }

            if (!((Grid)_cache).Children.Contains(view))
            {
                _root.Children.Add(view);
            }

            _view = view; 
            _view.Open();           
        }

        public async static void Close()
        {
            await _view.Close();
        }

    }
}


public static class PageExtensions
{
    public static ContentPage GetCurrentContentPage(this Page page)
    {
        if (page is ContentPage contentPage)
        {
            return contentPage;
        }
        else if (page is FlyoutPage flyoutPage)
        {
            return flyoutPage.Detail?.GetCurrentContentPage();
        }
        else if (page is Shell shell)
        {
            var currentPage = (ContentPage)shell.CurrentPage;
            return currentPage;
        }
        else if (page is NavigationPage navigationPage)
        {
            var lastPage = navigationPage.Navigation.NavigationStack.LastOrDefault();
            return lastPage?.GetCurrentContentPage();
        }
        else if (page is TabbedPage tabbedPage)
        {
            var currentPage = tabbedPage.CurrentPage?.GetCurrentContentPage();
            return currentPage;
        }
        else
        {
            return null;
        }
    }
}
