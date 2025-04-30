namespace UnityLLMGather.Core
{
    /// <summary>
    /// ファイルをどう扱うか。null は TreeOnly 扱い。
    /// </summary>
    public enum GatherMode
    {
        Drop,
        Full,
        Outline
    }
}
