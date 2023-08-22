
[TestClass]
public class TrieTest
{
    // Test that a word is inserted in the trie
    [TestMethod]
    public void TestInsert()
    {
        Trie dictionary = new Trie();
        dictionary.Insert("cat");
        Assert.IsTrue(dictionary.Search("cat"));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void TestDelete()
    {
        Trie dictionary = new Trie();
        dictionary.Insert("cat");
        dictionary.Delete("cat");
        Assert.IsFalse(dictionary.Search("cat"));
    }
}