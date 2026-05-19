using System;
using System.Collections.Generic;
using System.Text;
using AppJogoForca.Models;

namespace AppJogoForca.Repositories;

public class WordRepository
{
    private List<Word> _words;

    public WordRepository()
    {
        _words = new List<Word>();
        _words.Add(new Word("Nome", "Maria".ToUpper()));
        _words.Add(new Word("Vegetal", "Cenoura".ToUpper()));
        _words.Add(new Word("Fruta", "Abacate".ToUpper()));
        _words.Add(new Word("Tempero", "Nordestino".ToUpper()));
        _words.Add(new Word("Tempero", "Baiano".ToUpper()));
    }

    public Word GetWordRandom()
    {
        Random random = new Random();
        int index = random.Next(_words.Count);
        return _words[index];
    }
}
