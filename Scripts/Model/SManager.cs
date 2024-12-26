using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SManager : MonoBehaviour
{
    public static SManager instance = null;

    #region//ゲーム内パラメータ
    [Header("ミュート")] public bool IsMuted;
    [Header("SE音量")] public float SE_Volume;
    [Header("BGM音量")] public float BGM_Volume;
    [Header("BGMリスト")] public List<AudioClip> BGM_List;
    [Header("流れているBGMの番号")] public int BGM_idx;
    [Header("SE音源")] public AudioSource seSource = null;   //1つ目
    [Header("BGM音源")] public AudioSource bgmSource = null; //2つ目
    #endregion

    private void Awake()
    {
        // サウンドマネージャーは1つのみ存在
        if (instance == null) // まだ存在しない場合(ゲーム起動時)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // シーンを切り替えても保持されるように
        }
        else                  // すでに存在する場合(シーン切り替え時)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        seSource.volume = SE_Volume;
        bgmSource.volume = BGM_Volume;
        SetBGM(0);
        StartBGM();
    }

    void Update()
    {
        seSource.mute = IsMuted;
        bgmSource.mute = IsMuted;
        seSource.volume = SE_Volume;
        bgmSource.volume = BGM_Volume;
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <returns></returns>
    public void PlaySE(AudioClip clip)
    {
        if (seSource != null)
        {
            seSource.PlayOneShot(clip);
        }
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <returns></returns>
    public void StartBGM()
    {
        bgmSource.Play();
    }

    /// <summary>
    /// BGMを停止する
    /// </summary>
    /// <returns></returns>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// BGMを切り替える
    /// </summary>
    /// <returns></returns>
    public void SetBGM(int NewBGM)
    {
        BGM_idx = NewBGM;
        bgmSource.clip = BGM_List[BGM_idx];
    }
}
