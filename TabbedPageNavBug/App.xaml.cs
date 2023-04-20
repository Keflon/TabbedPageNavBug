namespace TabbedPageNavBug;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var tabbedPage = new TabbedPage();
        tabbedPage.Children.Add(new ContentPage() { Title = "No Nav root" });
        tabbedPage.Children.Add(new NavigationPage(new NavContentPage()){ Title = "Has Nav root" });
        tabbedPage.Children.Add(new NavigationPage(new NavContentPage()){ Title = "Has Nav root" });
        MainPage = tabbedPage;
    }

    public class NavContentPage : ContentPage
    {
        public NavContentPage()
        {
            var button = new Button() { Text = "Push a page", VerticalOptions = LayoutOptions.Start };
            button.Clicked += (s, e) => { this.Navigation.PushAsync(new NavContentPage()); };
            Content = button;
        }
    }
}
