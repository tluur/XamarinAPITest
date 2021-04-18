using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace App24
{
    public class API : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Namme { get; set; }
        public string dedcription { get; set; }
        public List<string> dough_ingredients { get; set; }
        public List<string> top_ingredients { get; set; }
        public string Method { get; set; }
        public int id { get; set; }

        private string _title;

        [JsonProperty("namme")]

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }









    }
}
