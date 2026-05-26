using System;
using System.Collections.Generic;
using System.Text;
using AppShoppingCenter.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Restaurants;

public partial class ListPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string textSearch;

    private List<Establishment> establishmentsFull;

    [ObservableProperty]
    private List<Establishment> establishmentsFiltered;

    public ListPageViewModel()
    {
        var service = App.Current?.Handler.MauiContext?.Services.GetService<RestaurantService>()!;
        establishmentsFull = service.GetRestaurants();
        establishmentsFiltered = establishmentsFull.ToList();
    }

    partial void OnTextSearchChanged(string value)
    {
        EstablishmentsFiltered = establishmentsFull
            .Where(a => a.Name.Contains(value ?? "", StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    [RelayCommand]
    private async void OnTapEstablishmentGoToDetailPage(Establishment establishment)
    {
        var navigationParameter = new Dictionary<string, object>()
        {
            { "establishment", establishment },
        };
        await Shell.Current.GoToAsync("detail", navigationParameter);
    }
}
