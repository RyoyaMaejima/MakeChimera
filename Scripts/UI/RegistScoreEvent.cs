using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistScoreEvent : MonoBehaviour
{
    [SerializeField] GameObject registScorePanel = null;
    [SerializeField] TMP_InputField inputField = null;
    [SerializeField] DataManager dataManager = null;
    
    // Start is called before the first frame update
    void Start()
    {
        // 初めはcreditPanelはactive falseにして隠す
        if (registScorePanel != null) registScorePanel.SetActive(false);
    }

    public void ClosePanel()
    {
        registScorePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        registScorePanel.SetActive(true);
    }


    public void RegistScore()
    {
        string registName = inputField.text;
        PlayerData playerData = new PlayerData(registName, GManager.instance.score);

        // Save実行
        dataManager.Save(playerData);

        // registPanelをcloseする
        ClosePanel();
    }

}


