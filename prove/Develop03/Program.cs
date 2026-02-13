using System;
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }
            scripture.HideRandomWords(3);
        }
        Console.WriteLine("Good job! You've cleared the scripture.");
    }
}
//CLASS: WORD
public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide() => _isHidden = true;
    public bool IsHidden() => _isHidden;
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}
//CLASS: REFERENCE
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        if (_endVerse == null)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
//Class: Scripture
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int actualToHide = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < actualToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
