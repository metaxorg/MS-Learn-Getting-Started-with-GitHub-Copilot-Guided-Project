---
title: Exercise - Debug code with Copilot Chat
description: Exercise - Debug code with Copilot Chat
durationInMinutes: 5
---

TODO - Introduction

## Use Copilot Chat to debug code

1. Open the **Trie.cs** file

1. Navigate to the `LevenshteinDistance` method

    The Levenshtein distance is a method for measuring the differences between two strings. The Levenshtein distance between two strings is defined as the minimum number of edits needed to transform one string into the other. The edit operations include insertion, deletion, or substitution of a character.

    In this code, the Levenshtein distance is calculated incorrectly. Let's use Copilot Chat to fix the error.

1. Select all of the code for the `LevenshteinDistance` method

1. Right click the selected code. Under **Copilot**, click **Start Copilot Chat**

1. In the textbox, enter "Fix this code"

    Copilot Chat may ask "Sure, what seems to be the issue with the code?" If so, enter "The Levenshtein distance is calculated incorrectly"

1. Wait for Copilot to generate new code.

    Copilot should suggest code that fixes an off by one error.

1. Click **Accept** to apply the fix.

## Use Copilot Chat to improve code

You can use Copilot Chat to improve code by adding new features or refactoring existing code. Let's use Copilot Chat to improve the `PrintTrie` method.

1. Open the **Program.cs** file

1. Navigate to the `PrintTrie` method

    This method prints the contents of the Trie to the console.

1. Select all of the code for the `PrintTrie` method

1. Right click the selected code. Under **Copilot**, click **Start Copilot Chat**

1. In the textbox, enter "Improve this code by separating the words into 5 columns"

1. Wait for Copilot to generate the new code.

    Copilot should suggest code that prints the words in 5 columns.

1. Click **Accept** to apply the changes.

## Check your work

In this task, you'll test the methods you created with Copilot to verify that they work as expected.

1. Open the **Program.cs** file

1. Comment out the call to the `Test` method:

    ```c#
    Trie dictionary = InitializeTrie(words);
    // Test();
    ```

1. Copy and paste the following code below the commented line:

    ```c#
    PrintTrie(dictionary);
    var similarWords = dictionary.GetSpellingSuggestions("cae");
    Console.WriteLine("Spelling suggestions for \"cae\":");
    foreach (var word in similarWords)
    {
        Console.WriteLine(word);
    }
    ```

1. In the file explorer, right click the **Program.cs** file and click **Open in Integrated Terminal**

1. Enter ```dotnet run``` to run the program.

1. Verify that your output is similar to the following

    ```Output
    The dictionary contains the following words:
    as             cars           follows        monday         plans
    astronaut      cares          from           monster        the
    asteroid       careful        front          place          their
    are            carefully      mellow         plan           they
    around         for            mean           planet         there
    cat            forgot         money          planets        towards
    Spelling suggestions for "cae":
    cat
    cars
    cares
    ```

    If your code displays different results, you'll need to review your code to find your error and make updates. Run the code again to see if you've fixed the problem. Continue updating and running your code until your code produces the expected results.

1. Remove the pasted code from the **Program.cs** file and uncomment the `Test` method call.