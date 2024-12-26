using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    [Header("スコア")] public int score;
    [Header("制限時間")] public float limitTime = 60;
    [HideInInspector] public bool isTimeAdvance = false;  // 時間が経過するかどうか
    public float gameTime = 0.0f;  // 経過時間 -> StageManagerで進める
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    if(isTimeAdvance)
    //    {
    //        gameTime += Time.deltaTime;
    //    }
    //}

    // スコアを増やす
    public void AddScore(int upScore)
    {
        score += upScore;
    }

    // 時間経過を止める
    public void StopTimer()
    {
        isTimeAdvance = false;
    }

    // 初期設定
    public void RetryGame()
    {
        score = 0;
        isTimeAdvance = true;
        gameTime = 0.0f;
    }
}
