using NotesApp.Models;
using NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        private ToDoRepository _toDoRepository;

        public ToDoPage()
        {
            InitializeComponent();
            _toDoRepository = new ToDoRepository();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var todos = _toDoRepository.GetAllToDos();

            // Create a Note object from each file

            myToDos.ItemsSource = todos;
        }

        private async void AddToDoClicked(object sender, EventArgs e)
        {
            // "nameof" gebruiken om te vermijden dat letterlijk naar klassen verwezen wordt
            await Shell.Current.GoToAsync(nameof(ToDoEntryPage));
        }
    }
}