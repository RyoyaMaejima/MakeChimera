using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("芝の座標")] public float greenRegion;

    private Vector3 mousePosition = Vector3.zero;  // マウスの位置
    private Vector3 offset = Vector3.zero;  // マウスの位置とオブジェクトの位置との差分
    private Vector3 previousPosition = Vector3.zero;
    private bool isDrag = false;  // ドラッグ中か
    private bool isSet = false;  // セット可能か
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }

        if (Input.GetMouseButton(0))
        {
            MouseDrag();
        }
        else
        {
            MouseUp();
        }
    }

    // マウスを押したとき
    void MouseDown()
    {
        offset = transform.position - mousePosition;
        previousPosition = transform.position;

        if (IsMouseOnAnimal())
        {
            isDrag = true;
        }
    }

    // ドラッグしているとき
    void MouseDrag()
    {
        if(isDrag)
        {
            transform.position = mousePosition + offset;
        }
    }

    // マウスを離したとき
    void MouseUp()
    {
        isDrag = false;
        
        if (transform.position.y >= greenRegion && !isSet)
        {
            transform.position = previousPosition;
        }
    }

    // マウスが動物の上にあるかどうか
    private bool IsMouseOnAnimal()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.transform.position == transform.position)
        {
            return true;
        }

        return false;
    }

    public bool GetIsDrag()
    {
        return isDrag;
    }

    public void SetIsSet(bool newIsSet)
    {
        isSet = newIsSet;
    }
}
