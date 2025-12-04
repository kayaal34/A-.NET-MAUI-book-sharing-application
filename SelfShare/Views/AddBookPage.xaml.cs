using System;
using Microsoft.Maui.Controls;

namespace SelfShare.Views;

public partial class AddBookPage : ContentPage
{
    public AddBookPage()
    {
        InitializeComponent();
    }

    private async void OnUploadPhotoTapped(object sender, EventArgs e)
    {
        // Placeholder: integrate file picker or media plugin
        await DisplayAlert("Upload", "Upload photo tapped (implement file picker).", "OK");
    }

    private async void OnAddBookClicked(object sender, EventArgs e)
    {
        var title = TitleEntry.Text?.Trim();
        var author = AuthorEntry.Text?.Trim();
        var description = DescriptionEditor.Text?.Trim();
        var condition = ConditionEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            await DisplayAlert("Validation", "Please enter title and author.", "OK");
            return;
        }

        // TODO: Save book to local list or call API
        await DisplayAlert("Success", "Book added.", "OK");

        // Navigate back to home
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch
        {
            await Navigation.PopAsync();
        }
    }
}
