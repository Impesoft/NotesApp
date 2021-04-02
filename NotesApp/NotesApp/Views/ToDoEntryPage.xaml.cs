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
    public partial class ToDoEntryPage : ContentPage
    {
        private ToDoRepository _toDoRepository;

        public ToDoEntryPage()
        {
            InitializeComponent();
            BindingContext = new ToDo();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todo = BindingContext as ToDo;

            if (todo != null)
            {
                _toDoRepository.SaveTodo(todo);
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todo = BindingContext as ToDo;

            if (todo != null)
            {
                _toDoRepository.DeleteTodo(todo);
            }
            // Navigate backwards -> Go back to previous screen
            await Shell.Current.GoToAsync("..");
        }
    }
}