# キメラの材料が決められない
![](https://github.com/RyoyaMaejima/MakeChimera/blob/main/ReadmeSrc/Title.png)

## ゲーム概要
- 第２回マーベラスゲームジャム作品（ユニーク賞受賞）
- リストに表示されたキメラの名前からあてはまる動物を選ぶ2Dパズルゲーム
- 左のボックス内の動物の１文字目と右のボックス内の２文字目を組み合わせることで、新たな名前のキメラを作り出すことができる

![](https://github.com/RyoyaMaejima/MakeChimera/blob/main/ReadmeSrc/Ingame.png)

![](https://github.com/RyoyaMaejima/MakeChimera/blob/main/ReadmeSrc/Chimera.png)

## 操作方法
- ドラッグ：動物を掴んで動かす
- ドロップ：動物をボックスの中に入れるContro

## プレイ方法
以下のマーベラスゲームジャムの特設サイトからプレイ可能です

https://gamejam.marv.jp/202408/

## 開発目的
- チーム開発におけるコミュニケーション能力や実装力を向上させること

## 開発環境・体制
- 人数：４人
- 担当：MVCモデルのController
- 期間：３日間
- 使用ツール：Unity

## ディレクトリ構成
Scripts内にソースコード一式を載せています  
Scripts/Controller/SelectとScripts/Model/Boxを実装しました  
以下が各ファイルの説明

- Select：動物をドラッグアンドドロップする挙動を管理するスクリプト
- Box：動物を入れる箱の挙動を管理するスクリプト

## こだわった点
- マウスカーソルと動物の距離を基にドラッグの可否を判定していたものを、動物のコリジョンとの接触判定に変えることで、あらゆる大きさの動物に対応できるようにした