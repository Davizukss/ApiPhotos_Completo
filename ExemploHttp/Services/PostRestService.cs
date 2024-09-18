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
	public class PostRestService
	{
		private HttpClient client;
        private Post post;
        private ObservableCollection<Post> posts;
		private JsonSerializerOptions serializerOptions;
        public PostRestService()
        {
            client = new HttpClient();
			serializerOptions= new JsonSerializerOptions{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
					WriteIndented = true
			};
		}

		public async Task<ObservableCollection<Post>> getPostAsync()
		{
			
			Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
			try
			{
				HttpResponseMessage response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, serializerOptions);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return posts;
		}
    }
}
