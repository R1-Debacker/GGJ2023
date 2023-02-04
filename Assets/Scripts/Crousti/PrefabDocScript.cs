using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PrefabDocScript : MonoBehaviour
{
    [SerializeField] public RectTransform rect;
    [SerializeField] public float lifetime;
    [SerializeField] public Image image;
    
    private Vector3 _scale;

    private void ApplyTag()
    {
        if (CompareTag("Red"))
        {
            image.color = Color.red;
        }
        else if (CompareTag("Blue"))
        {
            image.color = Color.blue;
        }
    }
    private void Awake()
    {
        lifetime = 4f;
        _scale = rect.localScale;

        int chance = Random.Range(0,3);
        tag = chance == 0 ? "Blue" : "Red";
    }

    private void Start()
    {
        ApplyTag();
        
        float rand_scale = Random.Range(2f, 4.5f);
        LeanTween.scale(rect, _scale * rand_scale, lifetime).setIgnoreTimeScale(true);
        
    }

    public bool ClickedLeft()
    {
        Destroy(gameObject,0.1f);
        return CompareTag("Blue");
    }
    public bool ClickedRight()
    {
        Destroy(gameObject,0.1f);
        return CompareTag("Red");
    }
}
