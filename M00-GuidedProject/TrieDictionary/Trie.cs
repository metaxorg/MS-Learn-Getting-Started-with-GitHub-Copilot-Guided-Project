public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public char _value;

    public TrieNode(char value = ' ')
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
        _value = value;
    }

    public bool HasChild(char c)
    {
        return Children.ContainsKey(c);
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public TrieNode _getNode()
    {
        return root;
    }

    public bool Search(string word)
    {
        TrieNode current = root;

        foreach (char c in word)
        {
            if (!current.HasChild(c))
            {
                return false;
            }
            current = current.Children[c];
        }

        return current.IsEndOfWord;
    }

    // Method to remove a word from the trie
    private bool RemoveNodes(TrieNode root, string word, int index)
    {
        if (index == word.Length)
        {
            if (!root.IsEndOfWord)
            {
                return false;
            }
            // Unmark the end of word
            root.IsEndOfWord = false;
            return root.Children.Count == 0;
        }

        // Recursively delete the word
        char c = word[index];
        TrieNode node = root.Children[c];
        if (node == null)
        {
            return false;
        }

        bool shouldDeleteCurrentNode = RemoveNodes(node, word, index + 1);

        if (shouldDeleteCurrentNode)
        {
            root.Children.Remove(c);
            return root.Children.Count == 0;
        }

        return false;
    }

    public bool Insert(string word)
    {
        TrieNode current = root;

        foreach (char c in word)
        {
            if (!current.HasChild(c))
            {
                current.Children[c] = new TrieNode(c);
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

    // TODO - not sure if this will be part of the starter code or not yet
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

    // TODO - not sure if this will be part of the starter code or not yet
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

    // TODO - If GetAllWordsWithPrefix is removed, this should be to
    public List<string> GetAllWords()
    {
        return GetAllWordsWithPrefix(root, "");
    }
}
