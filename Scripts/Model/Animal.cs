using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private string japaneseName = "　　";
    [SerializeField] private Image firstImage;
    [SerializeField] private Image lastImage;
    [SerializeField] private float defaultScale;
    [SerializeField] private float defaultRotation;
    [SerializeField] private float destroyTime;

    public AudioClip voice;


    // 先頭文字を取得
    public char GetFirstCharacter()
    {
        char firstCharacter = japaneseName[0];
        return firstCharacter;
    }

    // 末尾文字を取得
    public char GetLastCharacter()
    {
        char lastCharacter = japaneseName[japaneseName.Length - 1];
        return lastCharacter;
    }

    // 先頭画像を取得
    public Image GetFirstImage()
    {
        return firstImage;
    }

    // 末尾画像を取得
    public Image GetLastImage()
    {
        return lastImage;
    }

    // 初期スケールを取得
    public float GetDefaultScale()
    {
        return defaultScale;
    }

    // 初期回転を取得
    public float GetDefaultRotation()
    {
        return defaultRotation;
    }


    // 先頭文字を全角空白にする。
    public void ClearFirstCharacter()
    {
        japaneseName = "　"+japaneseName[1];
    }

    // 末尾文字を全角空白にする。
    public void ClearLastCharacter()
    {
        japaneseName = japaneseName[0]+"　";
    }

    // 先頭画像を削除
    public void ClearFirstImage()
    {
        firstImage = null;
    }

    // 末尾画像を削除
    public void ClearLastImage()
    {
        lastImage = null;
    }


    // 縮尺と回転を初期状態に設定
    private void SetScaleRotation()
    {
        transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = defaultRotation;
        transform.eulerAngles = currentRotation;
    }

    // 自己破壊処理
    public void DestroySelf()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // テスト
    private void Test()
    {
        Debug.Log($"{japaneseName}");
        Debug.Log($"First Character: {GetFirstCharacter()}");
        Debug.Log($"Last Character: {GetLastCharacter()}");
    }

    // テスト実行
    private void Start()
    {
        //Test();
        SetScaleRotation();
    }
}




