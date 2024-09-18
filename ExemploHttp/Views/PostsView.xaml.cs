using ExemploHttp.ViewModels;

namespace ExemploHttp.Views;

public partial class PostsView : ContentPage
{
	public PostsView()
	{
        InitializeComponent();
        BindingContext = new PostsViewModel();
	}
}