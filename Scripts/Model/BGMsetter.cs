using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMsetter : MonoBehaviour
{
    public int idx;

    // Start is called before the first frame update
    void Start()
    {
        SManager.instance.SetBGM(idx);
    }
}
