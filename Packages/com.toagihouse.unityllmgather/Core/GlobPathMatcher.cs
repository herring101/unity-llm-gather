using System.Text.RegularExpressions;

namespace UnityLLMGather.Core
{
    /// <summary>
    /// - 非依存版の超簡易 Glob → Regex 変換器
    ///   *   : 任意文字列（スラッシュ以外）
    ///   **  : 任意文字列（スラッシュ含む）
    ///   ?   : 任意 1 文字
    /// </summary>
    public sealed class GlobPathMatcher : IPathMatcher
    {
        public bool Match(string pattern, string path)
        {
            string regex = "^" + Regex.Escape(pattern)
                                .Replace(@"\*\*", "§§")   // 一旦エスケープ
                                .Replace(@"\*", "[^/]*")
                                .Replace("§§", ".*")
                                .Replace(@"\?", "[^/]")
                           + "$";

            return Regex.IsMatch(path.Replace('\\', '/'), regex,
                                 RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }
    }
}
