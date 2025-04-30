using System.IO;
using UnityEngine;

namespace UnityLLMGather.Core
{
    /// <summary>
    /// 設定ファイル (Project ルート直下に JSON) を読み書き。
    /// </summary>
    public sealed class GatherSettings
    {
        private const string FileName = "LLMGatherSettings.json";

        // --------------------------------------------------------------------
        // ★ C# 8 環境でもビルド出来るよう set アクセサに変更しています
        // --------------------------------------------------------------------
        public int TokenBudget { get; set; } = 100_000;
        public bool SceneAutoInclude { get; set; } = true;
        public PatternProfile Patterns { get; set; } = PatternProfile.CreateDefault();

        // --------------------------------------------------------------------

        /// <summary> 存在すればロード、無ければデフォルトを返す </summary>
        public static GatherSettings Load()
        {
            if (!File.Exists(FileName))
                return new GatherSettings();

            try
            {
                var json = File.ReadAllText(FileName);
                return JsonUtility.FromJson<GatherSettings>(json) ?? new GatherSettings();
            }
            catch
            {
                // 壊れていたら退避せず新規
                return new GatherSettings();
            }
        }

        public void Save()
        {
            var json = JsonUtility.ToJson(this, prettyPrint: true);
            File.WriteAllText(FileName, json);
        }
    }
}
