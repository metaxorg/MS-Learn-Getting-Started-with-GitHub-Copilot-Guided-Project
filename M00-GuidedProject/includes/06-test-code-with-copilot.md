---
title: Exercise - Test code with Copilot
description: Exercise - Test code with Copilot
durationInMinutes: 5
---

TODO - Introduction

## Use Copilot to test code

TODO some intro to the task

1. Open the **TrieTests.cs** file under **TrieDictionaryTest**

1. In the `TrieTest` class, enter the following code:

    ```c#
    // Test that a word is inserted in the trie
    [TestMethod]
    ```

1. Enter a new line, then wait for Copilot to generate code

    Copilot should generate code that inserts a word and asserts the word was inserted.

1. On a new line, enter the following code:

    ```c#
    // Test that a word is deleted from the trie
    [TestMethod]
    ```

1. Enter a new line, then wait for Copilot to generate code

    Copilot should generate code that inserts a word and asserts the word was deleted.

TODO more testing instructions

## Check your work

In this task, you'll test the methods you created with Copilot to verify that they work as expected.

1. In the file explorer, right click the **TrieTest.cs** file and click **Open in Integrated Terminal**

1. Enter ```dotnet test``` to run the tests.

1. Verify that all tests pass.

    ```Output
    Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 28 ms - TrieDictionaryTest.dll (net7.0)
    ```