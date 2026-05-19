using AppJogoForca.Libraries.Text;
using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca;

public partial class MainPage : ContentPage
{
    private Word _word;
    private int _errors;

    public MainPage()
    {
        InitializeComponent();

        ResetScreen();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.IsEnabled = false;

        string letter = button.Text;
        var indexes = _word.Text.AllIndexesOf(letter);

        if (indexes.Count == 0)
        {
            ErrorHandler(button);
            await IsGameOver();
            return;
        }

        ReplaceLetter(letter, indexes);
        button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"] as Style;

        await HasWinner();
    }

    private void OnButtonClickedResetGame(object sender, EventArgs e)
    {
        ResetScreen();
    }

    #region Verify if the player has won - Winner

    private void ReplaceLetter(string letter, List<int> indexes)
    {
        foreach (var index in indexes)
        {
            lblText.Text = lblText.Text.Remove(index, 1).Insert(index, letter);
        }
    }

    private async Task HasWinner()
    {
        if (!lblText.Text.Contains('_'))
        {
            await DisplayAlertAsync("Parabéns!", "Você ganhou!", "OK");
            ResetScreen();
        }
    }

    #endregion

    #region Verify if the player has lost - Game Over

    private void ErrorHandler(Button button)
    {
        _errors++;
        ImgMain.Source = ImageSource.FromFile($"forca{_errors + 1}.png");
        button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Fail"] as Style;
    }

    private async Task IsGameOver()
    {
        if (_errors == 6)
        {
            await DisplayAlertAsync(
                "Fim de jogo",
                $"Você perdeu! A palavra era: {_word.Text}",
                "OK"
            );
            ResetScreen();
        }
    }

    #endregion

    #region Reset Screen - Set Screen to Initial State

    private void ResetScreen()
    {
        ResetKeyboard();
        ResetErrors();
        GenerateWord();
    }

    private void ResetErrors()
    {
        ImgMain.Source = ImageSource.FromFile("forca1.png");
        _errors = 0;
    }

    private void ResetKeyboard()
    {
        ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[0]);
        ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[1]);
        ResetVirtualLines((HorizontalStackLayout)KeyboardContainer.Children[2]);
    }

    private void ResetVirtualLines(HorizontalStackLayout horizontal)
    {
        foreach (Button button in horizontal.Children)
        {
            button.IsEnabled = true;
            button.Style = null;
        }
    }

    private void GenerateWord()
    {
        var repository = new WordRepository();
        _word = repository.GetWordRandom();
        lblTips.Text = _word.Tips;
        lblText.Text = new string('_', _word.Text.Length);
    }

    #endregion
}
