using System;
using System.Collections.Generic;
using System.Text;
using AppShoppingCenter.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Cinemas;

public partial class ListPageViewModel : ObservableObject
{
    [ObservableProperty]
    private List<Movie> movies;

    public ListPageViewModel()
    {
        var service = App.Current?.Handler.MauiContext?.Services.GetService<CinemaService>()!;
        movies = service.GetMovies();
    }

    [RelayCommand]
    private async Task OnTapMovieGoToDetailPage(Movie movie)
    {
        var param = new Dictionary<string, object> { { "movie", movie } };

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            await Shell.Current.GoToAsync("detail", param);
        }
        else
        {
            await Shell.Current.GoToAsync("detaildesktop", param);
        }
    }
}
