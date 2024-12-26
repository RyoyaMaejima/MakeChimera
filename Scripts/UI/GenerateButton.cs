using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateButton : MonoBehaviour
{
    [SerializeField] private AudioClip okSE;
    [SerializeField] private AudioClip ngSE;
    [SerializeField] private StageManager stageManager = null;
    [SerializeField] private Generator generator = null;
    [SerializeField] private GenerateList generateList = null;

    // Chimeraを作れるなら作り、その後必要な処理を呼び出す。
    public void TryGenerateChimera()
    {
        if(generator.CheckGeneratable())
        {
            SManager.instance.PlaySE(okSE);

            // キメラ生成
            generator.GenerateChimera();

            // アンサーリストUIの更新
            generateList.SetAnswerList();

            // 使ったアニマルとキメラの破壊
            generator.DestroyAnimalsAndChimera();

            // ステージを更新する可能性がある
            stageManager.TryNewStage();
        }
        else
        {
            SManager.instance.PlaySE(ngSE);
        }
    }
}
