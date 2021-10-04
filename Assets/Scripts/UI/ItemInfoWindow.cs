using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoWindow : MonoBehaviour
{
    private Rect rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>().rect;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var offset = new Vector3(rectTransform.width, rectTransform.height) / 2;
        transform.position = Input.mousePosition + offset;
    }
}
