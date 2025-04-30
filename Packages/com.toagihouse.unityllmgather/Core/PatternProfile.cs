using System.Collections.Generic;

namespace UnityLLMGather.Core
{
    /// <summary>
    /// 収集ルールをまとめたプロファイル。
    /// - Drop    : まったく取り込まない
    /// - Full    : 全文を取り込む
    /// - Outline : 概要のみ
    /// それ以外（null）は TreeOnly 扱いになります。
    /// </summary>
    public sealed class PatternProfile
    {
        // --- properties -----------------------------------------------------

        /// <summary>完全除外パターン</summary>
        public IList<string> Drop { get; set; } = new List<string>();

        /// <summary>全文取得パターン</summary>
        public IList<string> Full { get; set; } = new List<string>();

        /// <summary>概要抽出パターン</summary>
        public IList<string> Outline { get; set; } = new List<string>();

        // --- factory --------------------------------------------------------

        public static PatternProfile CreateDefault() => new PatternProfile
        {
            Drop = new List<string>
            {
                "Library/**", "Temp/**", "*.meta"
            },

            Full = new List<string>
            {
                "**/*.cs"
            },

            Outline = new List<string>
            {
                "**/*.shader"
            }
        };
    }
}
