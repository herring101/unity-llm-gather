# Unity LLM Gather 2.0 (Work-in-Progress)

**⚠ 今は骨格だけです – 実装中!**

```

tree .
├─ Core/ ← Editor 非依存ロジック
├─ Editor/ ← UI・シーン連携
└─ Tests/ ← NUnit + EditMode

```

- 動かし方
  1. `DevProject` を Unity で新規作成
  2. `DevProject/Packages` に本パッケージをシンボリックリンクまたはコピー
  3. Project ウィンドウで _LLM Gather_ を確認
  4. `Window > General > Test Runner` → **EditMode** でテスト実行
