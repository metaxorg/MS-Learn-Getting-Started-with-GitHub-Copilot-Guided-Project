---
title: Exercise - Use Copilot to generate code
description: Exercise - Use Copilot to generate code
durationInMinutes: 10
---

TODO - Introduction

## Use Copilot to auto-complete code

TODO - Introduction

1. Open the **Trie.cs** file

1. Enter a new line after the `Trie` constructor, then enter the following code:

    ```c#
    // Search for a word in the trie
    public bool Search(string word) 
    {
    ```

1. Wait for Copilot to generate code. 

    Copilot may suggest code similar to following:

    ```c#
    // Search for a word in the trie
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
    ```

1. Press <kbd>Tab</kbd> or click **Accept** to apply the code suggestion.

    Sometimes Copilot might not have the exact code you need. You can use prompting to generate more specific code.

1. Enter a new line after the `Search` method, then enter the following code:

    ```c#
    // Delete a word from the trie
    public bool Delete(string word) 
    {
    ```

1. Wait for Copilot to generate code, then press <kbd>Tab</kbd> or click **Accept**

1. Take a moment to consider the code that Copilot auto-completed. 

    Feel free to prompt Copilot to generate comments to explain the code by entering a new line with forward slashes. 
    
    You may have a method similar to the following code:

    ```c#
    // Delete a word from the trie
    public bool Delete(string word)
    {
        TrieNode current = root;
        foreach (char c in word)
        {
            if (!current.HasChild(c))
            {
                // Word doesn't exist in trie
                return false;
            }
            current = current.Children[c];
        }
        if (!current.IsEndOfWord)
        {
            // Word doesn't exist in trie
            return false;
        }
        // Word exists in trie
        // Set IsEndOfWord to false
        current.IsEndOfWord = false;
        return true;
    }
    ```

    Notice that this code sets the value of `IsEndOfWord` to false, but it doesn't remove the nodes of the word from the trie. To delete these nodes, you'll need to prompt Copilot to be more specific.

## Prompt Copilot to generate specific code 

TODO - Introduction

1. Delete the previously generated `Delete` method.

1. On a new line, type the following comment:

    ```c#
    // Delete a word from the trie by removing all of its nodes
    ```
    
1. Enter a new line and wait for Copilot to suggest code. 

    You might notice that Copilot has multiple suggestions. You can click the arrow to navigate through suggestions.

    ![Copilot suggestions](../media/CopilotCodeSuggestions.png)

1. Press <kbd>Tab</kbd> or click **Accept** to apply the code suggestion that is similar to the following:

    ```c#
    // Delete a word from the trie by removing all of its nodes
    public bool Delete(string word)
    {
        return Delete(root, word, 0);
    }
    ```
        
    In this code, Copilot suggested a new `Delete` method that doesn't exist yet. You can prompt Copilot to generate this suggested method.

1. On a new line, enter `private bool Delete(`

1. Wait a moment for Copilot to populate the parameters and method code. It may take a few seconds.

    If you're having trouble getting Copilot to auto-complete the method, you can add the following parameters and wait for Copilot to complete the method code:

    ```c#
    private bool Delete(TrieNode current, string word, int index)
    {
    ```

1. Take a moment to consider the code that Copilot suggested. 

    You may want to prompt Copilot to generate comments to explain the code by entering a new line with forward slashes. 

    The code generated should perform the following tasks:

    1. Determine if the word to be deleted exists in the trie
    1. Update `IsEndOfWord` of the last node in the word
    1. Verify that the nodes not part of another word before deleting them
    1. Return true if the word was deleted, otherwise return false

    Here is one possible suggestion of the `Delete` method:

    ```c#
    private bool Delete(TrieNode current, string word, int index)
    {
        if (index == word.Length)
        {
            if (!current.IsEndOfWord)
            {
                return false;
            }
            current.IsEndOfWord = false;
            return current.Children.Count == 0;
        }
        char c = word[index];
        if (!current.HasChild(c))
        {
            return false;
        }
        TrieNode child = current.Children[c];
        bool shouldDeleteCurrentNode = Delete(child, word, index + 1) && !child.IsEndOfWord;
        if (shouldDeleteCurrentNode)
        {
            current.Children.Remove(c);
            return current.Children.Count == 0;
        }
        ```

1. Press <kbd>Tab</kbd> or click **Accept** to apply the code suggestion.

TODO - Conclusion