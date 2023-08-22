---
title: Exercise - Use Copilot to generate code
description: Exercise - Use Copilot to generate code
durationInMinutes: 10
---

As you develop with Copilot, you'll find that it can help you complete your code much faster. Copilot can auto-complete code that you're writing, and also suggest code that you might need. In this exercise, you'll use Copilot to generate new methods in the Trie project. Let's get started!

## Use Copilot to auto-complete code

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

Sometimes Copilot may not have the exact code you need. You can use prompting to generate more specific code.

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

## Check your work

In this task, you'll test the methods you created with Copilot to verify that they work as expected.

1. Open the **Program.cs** file.

1. Comment out the call to the `Test` method:

    ```c#
    Trie dictionary = InitializeTrie(words);
    // Test();
    ```

1. Copy and paste the following code below the commented line:

    ```c#
    PrintTrie(dictionary);
    Console.WriteLine("\nSearching for \"follows\" in trie: " + dictionary.Search("follows"));
    Console.WriteLine("Searching for \"forget\" in trie: " + dictionary.Search("forget"));
    Console.WriteLine("Deleting \"cars\" from trie...\n");
    dictionary.Delete("cars");
    PrintTrie(dictionary);
    ```

1. In the file explorer, right click the **Program.cs** file and click **Open in Integrated Terminal**

1. Enter ```dotnet run``` to run the program.

1. Verify that your output is similar to the following

    ```Output
    The dictionary contains the following words:
    as, astronaut, asteroid, are, around, cat, cars, cares, careful, carefully, for, forgot, follows, from, front, mellow, mean, money, monday, monster, place, plan, planet, planets, plans, the, their, they, there, towards,

    Searching for "follows" in trie: True
    Searching for "forget" in trie: False
    Deleting "cars" from trie...

    The dictionary contains the following words:
    as, astronaut, asteroid, are, around, cat, cares, careful, carefully, for, forgot, follows, from, front, mellow, mean, money, monday, monster, place, plan, planet, planets, plans, the, their, they, there, towards,
    ```

    If your code displays different results, you'll need to review your code to find your error and make updates. Run the code again to see if you've fixed the problem. Continue updating and running your code until your code produces the expected results.

1. Remove the pasted code from the **Program.cs** file and uncomment the `Test` method call.