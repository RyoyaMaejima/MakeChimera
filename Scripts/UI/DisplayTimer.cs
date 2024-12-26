using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        timerText.text = "残り時間: \n" + (GManager.instance.limitTime - (float)GManager.instance.gameTime).ToString("f1");
    }
}
