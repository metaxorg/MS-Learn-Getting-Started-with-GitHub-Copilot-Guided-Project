---
title: Exercise - Use Copilot to generate code
description: Exercise - Use Copilot to generate code
durationInMinutes: 5
---

TODO separate Copilot and Copilot Chat steps

TODO - Introduction

## Use Copilot to auto-complete code

Open Trie.cs
Enter the following:
```c#
public bool Search(string word) 
{
```
Wait for Copilot to generate code
Press <kbd>Tab</kbd> or click **Accept**


Enter the following:
```c#
// This method deletes a word from the Trie
public bool Delete(string word) 
{
```
Wait for Copilot to generate code
Press <kbd>Tab</kbd> or click **Accept**

Your method may look similar to the following code:
```c#
public bool Delete(string word) 
{
    var node = Root;
    foreach (var c in word) 
    {
        if (!node.Children.ContainsKey(c)) 
        {
            return false;
        }
        node = node.Children[c];
    }
    node.IsWord = false;
    return true;
}
```

This code only sets the `IsWord` method to false, but doesn't actually remove the word from the Trie. To delete the nodes of a word, you'll need to prompt Copilot to be more specific.

## Prompt Copilot to generate better code 
TODO make this title better

1. Delete the previously generated `Delete` method

TODO might rename this method
1. Enter the following code:

    ```c#
    // Remove the nodes of a given word from the Trie
    private bool RemoveNodes(TrieNode root, string word, int index)
    {
    ```
    
1. Wait for Copilot to generate code. You may get the following code suggestion:

    ```c#
    private bool RemoveNodes(TrieNode root, string word, int index)
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

        TrieNode child = root.Children[c];
        bool shouldDeleteChild = RemoveNodes(child, word, index + 1);

        if (shouldDeleteChild)
        {
            root.Children.Remove(c);
            return root.Children.Count == 0;
        }

        return false;
    }
    ```
1. Press <kbd>Tab</kbd> or click **Accept**

1. Create a public method to call the private `RemoveNodes` method. Enter the following code:

    ```c#
    public bool Delete(string word) 
    {
    ```

    As you type, Copilot should autocomplete the code to return the `RemoveNodes` method.

    ```c#
    public bool Delete(string word)
    {
        return RemoveNodes(Root, word, 0);
    }
    ```