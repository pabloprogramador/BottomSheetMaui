using System;
namespace BottomSheet.Components.Drawers
{
	public static class Drawer
	{
		private static BaseDrawer _view;
        private static Grid _root;
        private static ContentPage _contentPage;
        private static View _cache;

		public static void Open(BaseDrawer view)
		{
			_view = view;
			_contentPage = (ContentPage)App.Current.MainPage.GetCurrentContentPage();
            if (_contentPage == null)
            {
                System.Diagnostics.Debug.WriteLine("#### DRAWER BOTTOMSHEET - NOT CONTENTPAGE FOUND");
                return;
            }
			_cache = _contentPage.Content;
            _root = new Grid()
            {
                _cache,
                view
            };
            _contentPage.Content = _root;
            _view.Open();
            _view.CallBack = new Command(() =>
            {
                _contentPage.Content = _cache;
            });
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
