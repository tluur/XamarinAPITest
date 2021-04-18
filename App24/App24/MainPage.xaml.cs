using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App24
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "https://myt-pizza-api.herokuapp.com/pizzas"; //minu  API
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<API> _namme;


        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url); // Teeb Get
            List<API> pizzas = JsonConvert.DeserializeObject<List<API>>(content); 
            _namme = new ObservableCollection<API>(pizzas);
            MyListView.ItemsSource = _namme; 
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            API post = new API { Title = $" Lisame aja :  {DateTime.Now}" };  // Post aja
            string content = JsonConvert.SerializeObject(post); 
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            _namme.Insert(0, post); 
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            API post = _namme[0];
            await _client.DeleteAsync(Url + "/" + post.Id); //Kustutab id
            _namme.Remove(post);
        }
    }
}
