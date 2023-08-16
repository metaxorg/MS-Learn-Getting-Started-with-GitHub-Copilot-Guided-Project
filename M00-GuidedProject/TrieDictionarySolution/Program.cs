using System.Text;

string[] words = {
        "as", "astronaut", "asteroid", "are", "around",
        "cat", "cars", "cares", "careful", "carefully",
        "for", "follows", "forgot", "from", "front",
        "mellow", "mean", "money", "monday", "monster",
        "place", "plan", "planet", "planets", "plans",
        "the", "their", "they", "there", "towards"};

Trie dictionary = InitializeTrie(words);
PrintTrie(dictionary);
// GetPrefixInput();

var similarWords = dictionary.GetSpellingSuggestions("astrout");
Console.WriteLine("Spelling suggestions:");
foreach (var word in similarWords)
{
    Console.WriteLine(word);
}

// This method initializes a Trie data structure with the given array of words.
Trie InitializeTrie(string[] words)
{
    // Create a new Trie object.
    Trie trie = new Trie();

    // Insert each word in the array into the Trie.
    foreach (string word in words)
    {
        trie.Insert(word);
    }

    // Return the initialized Trie.
    return trie;
}

void Delete(string word)
{
    if (dictionary.Search(word))
    {
        dictionary.Delete(word);
    }
}

void PrintTrie(Trie trie)
{
    Console.WriteLine("The dictionary contains the following words:");
    List<string> words = trie.GetAllWords();
    foreach (string word in words)
    {
        Console.Write($"{word}, ");
    }
    Console.WriteLine();
}

void GetPrefixInput()
{
    Console.WriteLine("\nEnter a prefix to search for, then press Tab to " + 
                      "cycle through search results. Press Enter to exit.");

    bool running = true;
    string prefix = "";
    StringBuilder sb = new StringBuilder();
    List<string>? words = null;
    int wordsIndex = 0;

    while(running)
    {
        var input = Console.ReadKey(true);

        if (input.Key == ConsoleKey.Spacebar)
        {
            Console.Write(' ');
            prefix = "";
            sb.Append(' ');
            continue;
        } 
        else if (input.Key == ConsoleKey.Backspace && Console.CursorLeft > 0)
        {
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

            sb.Remove(sb.Length - 1, 1);
            prefix = sb.ToString().Split(' ').Last();
        }
        else if (input.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            running = false;
            continue;
        }
        else if (input.Key == ConsoleKey.Tab && prefix.Length > 1)
        {
            string previousWord = sb.ToString().Split(' ').Last();

            if (words != null) {
                if (!previousWord.Equals(words[wordsIndex - 1]))
                {
                    words = dictionary.AutoSuggest(prefix);
                    wordsIndex = 0;
                }
            } 
            else {
                words = dictionary.AutoSuggest(prefix);
                wordsIndex = 0;
            }

            for (int i = prefix.Length; i < previousWord.Length; i++)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                sb.Remove(sb.Length - 1, 1);
            }
        
            
            if (words.Count > 0 && wordsIndex < words.Count)
            {
                string output = words[wordsIndex++];
                Console.Write(output.Substring(prefix.Length));
                sb.Append(output.Substring(prefix.Length));
            }
            continue;
        }
        else if (input.Key != ConsoleKey.Tab)
        {
            Console.Write(input.KeyChar);
            prefix += input.KeyChar;
            sb.Append(input.KeyChar);
            words = null;
            wordsIndex = 0;
        }
    }
}