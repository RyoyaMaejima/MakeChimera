using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "スコア: "+GManager.instance.score;
    }
}
