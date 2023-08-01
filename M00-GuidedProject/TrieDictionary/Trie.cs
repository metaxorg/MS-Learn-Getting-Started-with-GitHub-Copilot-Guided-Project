public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public bool Insert(string word)
    {
        TrieNode current = root;

        foreach (char c in word)
        {
            if (!current.HasChild(c))
            {
                current.Children[c] = new TrieNode();
            }
            current = current.Children[c];
        }

        if (current.IsEndOfWord)
        {
            return false;
        }
        
        current.IsEndOfWord = true;
        return true;
    }

    public List<string> AutoSuggest(string prefix)
    {
        TrieNode currentNode = root;

        foreach (char c in prefix)
        {
            if (!currentNode.HasChild(c))
            {
                return new List<string>();
            }
            currentNode = currentNode.Children[c];
        }

        return GetAllWordsWithPrefix(currentNode, prefix);
    }

    private List<string> GetAllWordsWithPrefix(TrieNode root, string prefix)
    {
        List<string> words = new List<string>();

        if (root.IsEndOfWord)
        {
            words.Add(prefix);
        }

        foreach (char c in root.Children.Keys)
        {
            words.AddRange(GetAllWordsWithPrefix(root.Children[c], prefix + c));
        }

        return words;
    }

    public List<string> GetAllWords()
    {
        return GetAllWordsWithPrefix(root, "");
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }

    public bool HasChild(char c)
    {
        return Children.ContainsKey(c);
    }
}