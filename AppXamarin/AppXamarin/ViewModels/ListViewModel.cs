using AppXamarin.Models;
using AppXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace AppXamarin.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        private ApiService apiService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ToDo> List { get; set; }

        public ListViewModel()
        {
            this.apiService = new ApiService();
            this.Load();
        }

        private async void Load()
        {
            var response = (List<ToDo>)await apiService.GetList<ToDo>(
                "https://jsonplaceholder.typicode.com", "/todos");
            this.List = new ObservableCollection<ToDo>(response);
            //var auxList = response.Select(t => new ToDo
            //{
            //    userId = t.userId,
            //    title = t.title,
            //    completed = t.completed,
            //    id = t.id
            //});
        }
    }
}
