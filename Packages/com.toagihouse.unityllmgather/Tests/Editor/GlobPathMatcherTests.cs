using NUnit.Framework;
using UnityLLMGather.Core;

public class GlobPathMatcherTests
{
    [TestCase("**/*.cs", "Assets/Src/A.cs", true)]
    [TestCase("Library/**", "Library/obj/x.bin", true)]
    [TestCase("*.shader", "Shader/My.hlsl", false)]
    public void BasicMatch(string pattern, string path, bool expected)
    {
        var m = new GlobPathMatcher();
        Assert.AreEqual(expected, m.Match(pattern, path));
    }
}
