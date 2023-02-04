using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class GameWindow : MonoBehaviour
{
    [SerializeField] private GameObject small = null;
    [SerializeField] private GameObject big = null;

    private bool isStretched = false;
    private RectTransform rect = null;
    [SerializeField] private RectTransform canvasParent = null;
    private Vector2 sizeDelta = Vector2.zero;
    private Vector2 anchoredPosition = Vector2.zero;
    private Vector2 anchorMin = Vector2.zero;
    private Vector2 anchorMax = Vector2.zero;
    private Vector2 offsetMax = Vector2.zero;
    private Vector2 offsetMin = Vector2.zero;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        sizeDelta = rect.sizeDelta;
        anchoredPosition = rect.anchoredPosition;
        anchorMin = rect.anchorMin;
        anchorMax = rect.anchorMax;
        offsetMax = rect.offsetMax;
        offsetMin = rect.offsetMin;
    }

    public void Stretch()
    {
        if (isStretched)
        {
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMax = offsetMax;
            rect.offsetMin = offsetMin;
            rect.sizeDelta = sizeDelta;
            rect.anchoredPosition = anchoredPosition;
            isStretched = false;
            big.SetActive(true);
            small.SetActive(false);
        }
        else
        {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;
            rect.localScale = new Vector3(1, 1, 1);
            isStretched = true;
            big.SetActive(false);
            small.SetActive(true);
        }
        transform.SetAsLastSibling();
    }
}
