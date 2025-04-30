using System;

namespace UnityLLMGather.Core
{
    [Serializable]
    public sealed class FileMeta
    {
        public string Path { get; }
        public long SizeBytes { get; }
        public bool IsBinary { get; }
        public GatherMode? Mode { get; set; }   // null ＝ TreeOnly
        public int EstimatedTokens { get; set; }

        public FileMeta(string path, long sizeBytes, bool isBinary)
        {
            Path = path;
            SizeBytes = sizeBytes;
            IsBinary = isBinary;
        }
    }
}
