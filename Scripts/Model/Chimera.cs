using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chimera : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private string japaneseName = "";
    [SerializeField] private Image firstImage = null;
    [SerializeField] private Image lastImage = null;

    [SerializeField] private float defaultScale;
    [SerializeField] private float defaultRotation;
    [SerializeField] private float destroyTime;

    public string GetName()
    {
        return japaneseName;
    }

    // Animal 2つからキメラを初期化、奪い取った部分は元のAnimalから削除
    public void MakeChimera(Animal firstAnimal, Animal lastAnimal)
    {
        float firstScale = firstAnimal.GetDefaultScale();
        float lastScale = lastAnimal.GetDefaultScale();
        defaultScale = (firstScale + lastScale) / 2;
        SetScaleRotation();

        // 文字　をChimeraにセットして、Animal から削除
        char firstChara = firstAnimal.GetFirstCharacter();
        char lastChara = lastAnimal.GetLastCharacter();
        japaneseName = firstChara.ToString() + lastChara.ToString();

        firstAnimal.ClearFirstCharacter();
        lastAnimal.ClearLastCharacter();

        // 画像　をChimeraにセットしてCanvasの子オブジェクト化し、Animal から削除
        firstImage = firstAnimal.GetFirstImage();
        lastImage = lastAnimal.GetLastImage();

        firstImage.transform.parent = canvas.transform;
        lastImage.transform.parent = canvas.transform;

        // 画像のRectTransformをChimeraに合わせる
        StretchImage(firstImage);
        StretchImage(lastImage);

        firstAnimal.ClearFirstImage();
        lastAnimal.ClearLastImage();
    }

    // 画像をChimeraのキャンバスサイズに調整
    private void StretchImage(Image image)
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // 回転を戻す
        rectTransform.rotation = Quaternion.identity;

        // AnchorをStretchに設定
        rectTransform.anchorMin = new Vector2(0, 0); // 左下
        rectTransform.anchorMax = new Vector2(1, 1); // 右上

        // オフセットをリセット（Stretchに完全に合わせる）
        rectTransform.offsetMin = Vector2.zero; // 左下のオフセット
        rectTransform.offsetMax = Vector2.zero; // 右上のオフセット

        // スケールを1倍に
        rectTransform.localScale = Vector3.one;
    }


    private void SetScaleRotation()
    {
        transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = defaultRotation;
        transform.eulerAngles = currentRotation;
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
