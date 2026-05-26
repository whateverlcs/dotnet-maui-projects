using System;
using System.Collections.Generic;
using System.Text;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppShoppingCenter.ViewModels.Tickets;

public partial class CameraPageViewModel : ObservableObject
{
    [RelayCommand]
    private async Task BarcodeDetected(string ticketNumber)
    {
        var service = App.Current.Handler.MauiContext.Services.GetService<TicketService>();
        var ticket = service.GetTicket(ticketNumber);

        if (ticket == null)
        {
            await App.Current.MainPage.DisplayAlertAsync(
                "Ticket não encontrado!",
                $"Não localizamos um ticket com o número {ticketNumber}.",
                "OK"
            );
            return;
        }

        var param = new Dictionary<string, object>() { { "ticket", ticket } };

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync("../pay", param);
        });
    }
}
