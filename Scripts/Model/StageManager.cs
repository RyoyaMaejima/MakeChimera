using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private AudioClip stageSE;
    [SerializeField] private AudioClip timeUpSE;

    [SerializeField] private Game game = null;
    [SerializeField] private GenerateList generateList = null;

    //[SerializeField] private GameObject startPanel = null;



    // Start is called before the first frame update
    void Start()
    {
        
        

        // ゲームのリトライを呼び出す
        GManager.instance.RetryGame();

        // 準備の演出
        // 「沢山キメラを作れ！」
        // 「Ready?」
        // 「Go!」

        

        
        

        newStage();
    }


    // 新しいステージを整える。問題作成、表示、SE。
    private void newStage()
    {
        // game start
        game.InitGame();
        generateList.SetAnswerList();
        SManager.instance.PlaySE(stageSE);
    }

    public void TryNewStage()
    {
        // ステージ終了なら初期化
        if(game.CheckStageEnd())
        {
            newStage();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // ゲームタイムを進める
        GManager.instance.gameTime += Time.deltaTime;

        // 時間オーバーしたら、
        if (GManager.instance.gameTime > GManager.instance.limitTime)
        {
            SManager.instance.PlaySE(timeUpSE);
            
            // SEが鳴り終わるの待ちたい

            SceneManager.LoadScene("Result");
        }
    }
}
