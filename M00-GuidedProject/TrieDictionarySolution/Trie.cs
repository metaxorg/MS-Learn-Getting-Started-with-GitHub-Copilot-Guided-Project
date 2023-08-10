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

    // Learner will write this code
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
    
    public bool Insert(string word)
    {
        // Start at the root node
        TrieNode current = root;

        // For each character in the word
        foreach (char c in word)
        {
            // If the current node doesn't have a child with the current character
            if (!current.HasChild(c))
            {
                // Add a new child with the current character
                current.Children[c] = new TrieNode(c);
            }
            // Move to the child node with the current character
            current = current.Children[c];
        }

        if (current.IsEndOfWord)
        {
            // Word already exists in the trie
            return false;
        }
        
        // Mark the end of the word
        current.IsEndOfWord = true;

        // Word successfully inserted into the trie
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

    /// <summary>
    /// Recursively gets all words in the trie that start with the given prefix.
    /// </summary>
    /// <param name="root">The root node of the trie.</param>
    /// <param name="prefix">The prefix to search for.</param>
    /// <returns>A list of all words in the trie that start with the given prefix.</returns>
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

    // Learner will write this code
    private bool DeleteHelper(TrieNode root, string word, int index)
    {
        if (index == word.Length)
        {
            if (!root.IsEndOfWord)
            {
                return false;
            }
            root.IsEndOfWord = false;
            return root.Children.Count == 0;
        }

        char c = word[index];
        if (!root.HasChild(c))
        {
            return false;
        }

        bool shouldDeleteCurrentNode = DeleteHelper(root.Children[c], word, index + 1);

        if (shouldDeleteCurrentNode)
        {
            root.Children.Remove(c);
            return root.Children.Count == 0;
        }

        return false;
    }

    // Learner will write this code
    public bool Delete(string word)
    {
        return DeleteHelper(root, word, 0);
    }

    public void PrintTrieStructure()
    {
        Console.WriteLine("\nroot");
        _printTrieNodes(root);
    }

    private void _printTrieNodes(TrieNode root, string format = " ", bool isLastChild = true) 
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
}
