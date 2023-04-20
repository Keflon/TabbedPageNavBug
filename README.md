# TabbedPageNavBug

### Description

Given a `TabbedPage` with Children, where 
- at least one Tab *does not* have a NavigationPage
- at least one Tab *does* have a NavigationPage

If a back button is shown for the `CurrentPage`, then swapping to a Tab that does not have a `NavigationPage` does not remove the back button.

Notes:
Swapping to a Tab that does have a `NavigationPage` correctly updates the back-button depending on whether the current `NavigationPage` requires it.



### Steps to Reproduce

1. Create a new MAUI app.
1. Replace the contents of App.xaml.cs with this:
```csharp
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
```
1. Run it on Windows.
1. Swap to either the second or third Tab.
2. Click the button
3. The back button appears. This is correct.
![image](https://user-images.githubusercontent.com/16598898/233381995-4f26324f-4861-4aed-bb7b-99b0df36c9c1.png)
  

4. Swap to the first Tab. 
5. The back-button remains. This is the bug. 
![image](https://user-images.githubusercontent.com/16598898/233383965-f5c83f8a-15d4-491b-b79a-16518aea03e9.png)




### Link to public reproduction project repository

https://github.com/Keflon/TabbedPageNavBug

### Version with bug

7.0 (current)

### Last version that worked well

Unknown/Other

### Affected platforms

Windows

### Affected platform versions

Latest

### Did you find any workaround?

No.

### Relevant log output

_No response_