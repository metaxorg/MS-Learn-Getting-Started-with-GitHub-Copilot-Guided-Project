string[] words = {
        "as", "astronaut", "asteroid", 
        "cat", "cars", "cares", "careful", "carefully",
        "money", "monday", "mellow", "monster",
        "place", "plan", "planet", "planets", "plans",
        "the", "their", "they", "there"};

Trie dictionary = InitializeTrie(words);
PrintTrie(dictionary);
GetPrefixInput();

Trie InitializeTrie(string[] words)
{
    Trie trie = new Trie();
    foreach (string word in words)
    {
        trie.Insert(word);
    }

    return trie;
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
    Console.WriteLine("\nEnter a prefix to search for. Press Tab to cycle through suggestions. Press Enter to exit.");

    bool running = true;
    string suggestedWord = "";
    string prefix = "";
    string buffer = "";
    List<string> words = null;
    int wordsIndex = 0;

    while(running)
    {
        var input = Console.ReadKey(true);
        if (input.Key == ConsoleKey.Spacebar)
        {
            Console.Write(' ');
            prefix = "";
            suggestedWord = "";
            continue;
        } 
        else if (input.Key == ConsoleKey.Backspace)
        {
            // TODO this is buggy when the user erases part of the suggested word and hits tab again
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

            prefix = prefix.Substring(0, prefix.Length - 1);
        }
        else if (input.Key == ConsoleKey.Enter)
        {
            Console.Write(input.KeyChar);
            running = false;
            continue;
        }
        else if (input.Key == ConsoleKey.Tab && prefix.Length > 1)
        {
            if (words == null) {
                words = dictionary.AutoSuggest(prefix);
            }
            // Delete the suggested word from the Console Output
            for (int i = prefix.Length; i < suggestedWord.Length; i++)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(' ');
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            
            if (words.Count > 0 && wordsIndex < words.Count)
            {
                suggestedWord = words[wordsIndex++];
                Console.Write(suggestedWord.Substring(prefix.Length));
            }
            continue;
        }
        else if (input.Key != ConsoleKey.Tab)
        {
            Console.Write(input.KeyChar);
            prefix += input.KeyChar;
            words = null;
            wordsIndex = 0;
        }
    }
}

void PrintTrieStructure(Trie trie)
{
    TrieNode root = trie._getNode();
    Console.WriteLine("\nroot");
    _printTrieNodes(root);
}

void _printTrieNodes(TrieNode root, string format = " ", bool isLastChild = true) 
{
    if (root == null)
        return;

    Console.Write($"{format}");

    if (isLastChild)
    {
        Console.Write("└─");
        format += "  ";
    }
    else
    {
        Console.Write("├─");
        format += "│ ";
    }

    Console.WriteLine($"{root._value}");

    int childCount = root.Children.Count;
    int i = 0;
    var children = root.Children.OrderBy(x => x.Key);

    foreach(var child in children)
    {
        i++;
        bool isLast = i == childCount;
        _printTrieNodes(child.Value, format, isLast);
    }
}