using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    public void SetNameText(string text)
    {
        nameText.text = text;
    }

    public void SetScoreText(string text)
    {
        scoreText.text = text;
    }

}
