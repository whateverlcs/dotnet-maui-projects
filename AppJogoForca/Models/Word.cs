using System;
using System.Collections.Generic;
using System.Text;

namespace AppJogoForca.Models;

public class Word
{
    public Word(string tips, string text)
    {
        Tips = tips;
        Text = text;
    }

    public string Tips { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
