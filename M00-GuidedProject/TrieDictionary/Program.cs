string[] words = {
        "as", "astronaut", "asteroid", 
        "cat", "cars", "cares", "careful",
        "money", "monday", "mellow", "monster"};

Trie dictionary = InitializeTrie(words);
PrintTrie(dictionary);
GetPrefixInput();
PrintTrieStructure(dictionary);

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
    List<string> words = trie.GetAllWords();
    foreach (string word in words)
    {
        Console.WriteLine(word);
    }
}

void GetPrefixInput()
{
    Console.WriteLine("Enter a prefix to search for:");
    string prefix = Console.ReadLine();
    List<string> words = dictionary.AutoSuggest(prefix);
    foreach (string word in words)
    {
        Console.WriteLine(word);
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