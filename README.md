# Oxygen Not Included - 日本語フォントパッチ

## これはなに？

Klei Entertainment のコロニーシミュレーションゲーム『[Oxygen Not Included](https://www.klei.com/games/oxygen-not-included)』の日本語フォントを、ちょっといい感じにする MOD です。

詳しくは [Steam Workshop のページ](https://steamcommunity.com/sharedfiles/filedetails/?id=3135364297) をご覧ください。

## 使用フォント

- [きんいろサンセリフ](http://getsuren.com/kiniro_series.html)
- [せのびゴシック](https://modi.jpn.org/font_senobi.php)

## 環境構築

### Dev Container を使う場合

1. `.devcontainer/.env.template` をコピーして `.env` にリネームする
1. 次の通り書き換える
   - `ONI_CLIENT_DLL_PATH` ... ONI がインストールされているディレクトリの、DLL がいっぱい入っている `Managed` ディレクトリへの絶対パス
   - `ONI_LOCAL_DEV_MOD_PATH` ... ユーザーディレクトリにある ONI の MOD ディレクトリへの絶対パス + `/Dev`
1. Dev Container を立ち上げれば開発できるようになっている

### ホスト OS に全部入っている場合 (動作未確認)

1. `Directory.Build.props` を次の通り書き換える
   - `GameClientDllPath` ... ↑の `ONI_CLIENT_DLL_PATH` と同じ
   - `LocalDestinationPath` ... ↑の `ONI_LOCAL_DEV_MOD_PATH` と同じ
1. だいたいうまくいくようになっている (はず)

## ビルド

普通の C# プロジェクトと同じようにビルドしてください。

ビルドを行うと、DLL と `resources` ディレクトリの中身が ONI の開発用 MOD ディレクトリに自動的にデプロイされ、ゲームから読み取れるようになります。

## 謝辞

- すばらしいフォントを作っていただきありがとうございます。
  - [きんいろ書体シリーズ (きんいろサンセリフ)](http://getsuren.com/kiniro_series.html)
  - [フリーフォントのMODI工場 (せのびゴシック)](https://modi.jpn.org/font_senobi.php)
- 以下の解説にはとても助けられました。
  - [[Oxygen Not Included] MOD作製ことはじめ（日本語版）](https://github.com/pasaran66088459/how_to_create_oni_mods_japanese)
  - [A Guide to Oxygen Not Included Modding](https://github.com/Cairath/Oxygen-Not-Included-Modding)
  - [TextMesh Proを使用したUnity製ゲームのフォントの差し替え方法について](https://steamcommunity.com/sharedfiles/filedetails/?id=2869701209)
- 以下のリポジトリのコードは大いに参考にさせてもらいました。
  - [dershiuan's Mods for Oxygen Not Include](https://github.com/dershiuan/ONI-Mods)
  - [miZyind's ONI Mods](https://github.com/miZyind/ONI-Mods)
  - [Peter Han's Mods for Oxygen Not Included](https://github.com/peterhaneve/ONIMods)
  - [Sgt_Imalas-Oni-Mods](https://github.com/Sgt-Imalas/Sgt_Imalas-Oni-Mods)
