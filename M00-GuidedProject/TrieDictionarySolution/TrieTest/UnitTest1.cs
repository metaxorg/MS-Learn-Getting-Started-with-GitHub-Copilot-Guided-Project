/*using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrieTest;

[TestClass]
public class UnitTest1
{
    // Initialize a Trie that can be used by all test methods
    private static Trie _trie = new Trie();
    private static string[] words = { "apple", "app", "application", "applied", "apply", "appreciate", "appreciation", "appreciative" };

    // Test that words are correctly inserted into the trie
    [TestMethod]
    public void InsertTest()
    {
        foreach (string word in words)
        {
            _trie.Insert(word);
        }

        foreach (string word in words)
        {
            Assert.IsTrue(_trie.Search(word));
        }
    }
*/