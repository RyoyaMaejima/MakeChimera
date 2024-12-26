using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    // #################
    // データのSave機能
    // #################
    public void Save(PlayerData playerData)
    {
        // これまでのデータをロードする
        List<PlayerData> allPlayerData = Load();
        allPlayerData.Add(playerData);

        // シリアライズ化してPlayerPrefsで書き込む
        string json = JsonUtility.ToJson(new PlayerDataList(allPlayerData), true);
        PlayerPrefs.SetString("playersData", json);

    }

    public List<PlayerData> Load()
    {
        // PlayerPrefsでデータを保持する
        string json = PlayerPrefs.GetString("playersData", "");
        PlayerDataList playerDataList = JsonUtility.FromJson<PlayerDataList>(json);

        // json == "" => return empty list
        if (playerDataList == null) return new List<PlayerData>();
        else return playerDataList.playersData;
    }


    public void SortByScore(List<PlayerData> pData)
    {
        pData.Sort((a, b) => b.score.CompareTo(a.score));
    }
}



// ####################
// PlayerDataの保存
// ####################

// 保管するデータ構造
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

// PlayerDataを保持するリスト
[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> playersData;

    public PlayerDataList()
    {
        playersData = new List<PlayerData>();
    }

    public PlayerDataList(List<PlayerData> playersData)
    {
        this.playersData = playersData;
    }
}