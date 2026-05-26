using System;
using System.Collections.Generic;
using System.Text;
using AppShoppingCenter.Services;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Tickets;

public partial class ScanPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string ticketNumber;

    [RelayCommand]
    private void Scan()
    {
        Shell.Current.GoToAsync("camera");
    }

    async partial void OnTicketNumberChanged(string value)
    {
        if (value?.Length < 15)
            return;

        var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
        var ticket = service.GetTicket(value);

        if (ticket == null)
        {
            await App.Current.MainPage.DisplayAlertAsync(
                "Ticket não encontrado!",
                $"Não localizamos um ticket com o número {value}.",
                "OK"
            );
            return;
        }

        var param = new Dictionary<string, object>() { { "ticket", ticket } };
        await Shell.Current.GoToAsync("pay", param);
        TicketNumber = string.Empty;
    }

    [RelayCommand]
    private void List()
    {
        Shell.Current.GoToAsync("list");
    }
}
