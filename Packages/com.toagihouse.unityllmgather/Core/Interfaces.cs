using System.Collections.Generic;

namespace UnityLLMGather.Core
{
    public interface IPathMatcher { bool Match(string pattern, string path); }
    public interface IScanner { IEnumerable<FileMeta> Scan(string rootDir); }
    public interface ISceneAnalyzer { IEnumerable<string> GetScriptGuidsInActiveScene(); }
    public interface ITokenEstimator { int Estimate(string text); }
    public interface ISelectionPlanner
    {
        IEnumerable<FileMeta> Plan(IEnumerable<FileMeta> allFiles);
    }
    public interface IContentExtractor { string Extract(FileMeta meta); }
    public interface IContentWriter
    {
        void Write(System.IO.StreamWriter sw, IEnumerable<FileMeta> files);
    }
}
