string[] words = {
        "as", "astronaut", "asteroid", 
        "cat", "cars", "cares", "careful",
        "money", "monday", "mellow", "monster"};

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