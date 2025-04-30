using UnityEditor;
using UnityEngine;
using UnityLLMGather.Core;

namespace UnityLLMGather.Editor
{
    public class GatherWindow : EditorWindow
    {
        [MenuItem("Tools/Unity LLM Gather 2.0")]
        private static void Open() => GetWindow<GatherWindow>("LLM Gather");

        private void OnGUI()
        {
            GUILayout.Label("Unity LLM Gather 2.0 — WIP", EditorStyles.boldLabel);
            if (GUILayout.Button("Generate Summary"))
            {
                Debug.Log(">>> TODO: pipeline.Execute()");
            }
        }
    }
}
