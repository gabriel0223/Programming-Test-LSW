using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverGrowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    [SerializeField] private float hoverScaleMultiplier;
    [SerializeField] private float animationDuration;
    [SerializeField] private string hoverSound;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalScale * hoverScaleMultiplier, animationDuration);
        AudioManager.instance.Play(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, animationDuration);
    }
}
