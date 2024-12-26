using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditEvent : MonoBehaviour
{
    [SerializeField] GameObject creditPanel = null;
    // Start is called before the first frame update
    void Start()
    {
        // 初めはcreditPanelはactive falseにして隠す
        if (creditPanel != null) creditPanel.SetActive(false);
    }

    public void ClosePanel()
    {
        creditPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        creditPanel.SetActive(true);
    }

}
