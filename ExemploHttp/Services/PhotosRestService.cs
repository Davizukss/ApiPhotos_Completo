using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHttp.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace ExemploHttp.Services
{
    public class PhotosRestServices
    {
        private HttpClient client;
        private Photo photo;
        ObservableCollection<Photo> photos;
        private JsonSerializerOptions serializerOptions;
        public PhotosRestServices()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Photo>> getPhotosAsync()
        {

            Uri uri = new Uri("https://jsonplaceholder.typicode.com/photos");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    photos = JsonSerializer.Deserialize<ObservableCollection<Photo>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return  photos;
        }
    }
}
