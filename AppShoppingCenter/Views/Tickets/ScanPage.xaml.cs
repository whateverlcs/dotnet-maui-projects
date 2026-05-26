using System.ComponentModel;
using AppShoppingCenter.ViewModels.Tickets;
using CommunityToolkit.Maui.Core.Platform;

namespace AppShoppingCenter.Views.Tickets;

public partial class ScanPage : ContentPage
{
    public ScanPage()
    {
        InitializeComponent();
    }

    private void CursorFix(object sender, TextChangedEventArgs e)
    {
        Entry input = (Entry)sender;

        input.CursorPosition = input.Text.Length;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Observa quando TicketNumber for limpo após pagamento
        if (BindingContext is ScanPageViewModel vm)
        {
            vm.PropertyChanged += OnViewModelPropertyChanged;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is ScanPageViewModel vm)
        {
            vm.PropertyChanged -= OnViewModelPropertyChanged;
        }
    }

    private async void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (
            e.PropertyName == nameof(ScanPageViewModel.TicketNumber)
            && string.IsNullOrEmpty(ticketEntry.Text)
        )
        {
            await ticketEntry.HideKeyboardAsync(CancellationToken.None);
        }
    }
}
