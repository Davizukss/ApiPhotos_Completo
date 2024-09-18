
using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHttp.Models;
using ExemploHttp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ExemploHttp.ViewModels;

public partial class PhotosViewModel : ObservableObject
{
	[ObservableProperty]
	ObservableCollection<Photo> photos;

    public ICommand getPhotosCommand { get; }

    public PhotosViewModel()
    {
        getPhotosCommand = new Command(getPhotos);
    }

    public async void getPhotos()
    {
        PhotosRestServices restService = new PhotosRestServices();
        photos = await restService.getPhotosAsync();
    }


}
