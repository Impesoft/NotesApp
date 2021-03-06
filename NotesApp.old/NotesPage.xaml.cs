using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            // Create a Note object from each file
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");

            foreach (var file in files)
            {
                notes.Add(new Note
                {
                    FileName = file,
                    Text = File.ReadAllText(file),
                    Date = File.GetCreationTime(file),
                });
            }

            // Bind a list of items to a collectionView
            myNotes.ItemsSource = notes;
        }

        private void myNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void AddNoteClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NoteEntryPage");
        }
    }
}