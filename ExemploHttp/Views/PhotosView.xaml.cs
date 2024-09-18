using ExemploHttp.ViewModels;

namespace ExemploHttp.Views;

public partial class PhotosView : ContentPage
{
	public PhotosView()
	{
        BindingContext = new PhotosViewModel();
        InitializeComponent();
	}
}