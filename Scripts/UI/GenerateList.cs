using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateList : MonoBehaviour
{
    [SerializeField] private AudioClip completeSE;
    [SerializeField] private AudioClip correctSE;
    [SerializeField] private Game game = null;
    [SerializeField, Header("gameの解リスト")] private List<TextMeshProUGUI> generateList = new List<TextMeshProUGUI>();
    //[SerializeField, Header("解が生成されたかどうか")] private List<TextMeshProUGUI> isGeneratedList = new List<TextMeshProUGUI>();
    [SerializeField] private List<GameObject> isGeneratedList = new List<GameObject>();

    private int beforeNumCorrect = 0;


    public void SetAnswerList()
    {
        // キメラnameをセット
        int i = 0;
        foreach(string key in game.answerChimeraNames.Keys)
        {
            generateList[i].text = key;
            i++;
        }

        // 指示されたキメラが生成されたかどうか
        i = 0;
        foreach(bool b in game.answerChimeraNames.Values)
        {
            isGeneratedList[i].SetActive(b);
            i++;
        }

        // 正解数が増えた時に音が鳴る
        int afterNumCorrect = game.GetNumCorrect();
        if(beforeNumCorrect < afterNumCorrect)
        {
            if(afterNumCorrect == generateList.Count)
            {
                SManager.instance.PlaySE(completeSE);
            }
            else
            {
                SManager.instance.PlaySE(correctSE);
            }
            
        }
        beforeNumCorrect = afterNumCorrect;
    }

}
