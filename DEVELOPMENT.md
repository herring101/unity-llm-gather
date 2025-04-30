# Unity LLM Gather — Development Guide 0.1

_初回環境構築 & リポジトリ公開までの手順書_

---

## 0. 前提バージョン

| Tool           | Version (tested)      |
| -------------- | --------------------- |
| **Unity**      | 2022.3 LTS            |
| **Git**        | 2.43+                 |
| **GitHub CLI** | 2.46+                 |
| **OS**         | Windows 11 / macOS 13 |

---

## 1. フォルダ構成

```

unity-llm-gather/
├─ Packages/
│ └─ com.toagihouse.unityllmgather/
│ ├─ Core/
│ ├─ Editor/
│ ├─ Tests/
│ ├─ package.json
│ └─ (各 .asmdef / \*.cs ...)
├─ DevProject/ ← 検証用 Unity プロジェクト
├─ .gitignore
└─ DEVELOPMENT.md ← ★ このドキュメント

```

---

## 2. パッケージ骨格の実装

- **Core 層**
  - `GatherMode`, `FileMeta`, `PatternProfile`, `GatherSettings`
  - `GlobPathMatcher` — 外部依存を避けて自前実装
- **Editor 層**
  - `GatherWindow` — プレースホルダ UI
- **Tests**
  - `GlobPathMatcherTests`（EditMode、NUnit）

### C#-8 対応

`init` アクセサは未サポートなので **`set` に変更**（`CS0518` 回避）。
将来 Unity が C# 9+ に上がったら `IsExternalInit` ダミー型を削除して `init` に戻せる。

---

## 3. Git & GitHub までのコマンドログ（抜粋）

```bash
# 1. リモートが無ければ作成
gh repo create herring101/unity-llm-gather --public --source=. --remote=origin --push

# 2. .gitignore を追加して初回コミット
git add .
git commit -m "feat: initial skeleton (Core/Editor/Tests)"
git push -u origin main
```

> SSH 認証は `ssh -T git@github.com` で確認。  
> エラー「Repository not found」は **GitHub 上に空リポジトリを先に作る** ことで解消。

---

## 4. DevProject での組み込み手順（再掲）

1. Unity Hub → 3D Core テンプレートで `DevProject` 作成
2. `DevProject/Packages` にシンボリックリンク
   ```bash
   # Windows (PowerShell)
   cmd /c mklink /D com.toagihouse.unityllmgather ..\..\Packages\com.toagihouse.unityllmgather
   ```
3. Unity 起動 → `Window ▸ General ▸ Test Runner (EditMode)` でテスト緑

---

## 5. 直近ロードマップ

| Milestone | 目標                                                    | 担当ディレクトリ                           | 見積  |
| --------- | ------------------------------------------------------- | ------------------------------------------ | ----- |
| **M2**    | `Scanner` 実装 & テスト                                 | `Core/Scanner.cs`, `Tests/ScannerTests.cs` | 0.5 d |
| **M3**    | `TokenEstimator` & `SelectionPlanner`                   | `Core/TokenEstimator.cs` …                 | 1 d   |
| **M4**    | `FullExtractor` / `OutlineExtractor`（Roslyn optional） | `Core/Extractors/`                         | 1 d   |
| **M5**    | `ContentWriter` + `GatherPipeline` 結合                 | `Core/…`                                   | 0.5 d |
| **M6**    | 新 UI (`GatherWindow`) フル実装                         | `Editor/`                                  | 0.5 d |
| **M7**    | GitHub Actions CI（EditMode テスト）                    | `.github/workflows/ci.yml`                 | 0.5 d |

_日付感覚：d = “人日“ 目安。_  
テストを先に書く → 実装 → テスト緑 → Push のサイクルを維持する。

---

## 6. ブランチ戦略

```text
main      : 安定版 (タグ付き)
develop   : 次バージョン開発
feat/*    : 機能
fix/*     : バグ
```

- Pull Request マージ時に **EditMode テストが緑** を必須チェックに設定予定。

---

## 7. 参考リンク

- Unity Manual — [Custom packages](https://docs.unity3d.com/Manual/CustomPackages.html)
- GitHub Actions — [unity-actions/setup-unity](https://github.com/marketplace/actions/setup-unity)
- NUnit — [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.3/manual/index.html)

---

_更新履歴_  
_2025-04-30 — 初版_

````

---

### 次のステップ

1. **`DEVELOPMENT.md` をプロジェクトに追加してコミット**
   ```bash
   git add DEVELOPMENT.md
   git commit -m "docs: add development guide 0.1"
   git push
````

2. **M2: Scanner 実装** に着手  
   _インターフェース (`IScanner`) とテストを先に書き、  
   `Directory.EnumerateFiles` → `FileMeta` 生成を TDD で進める。_
