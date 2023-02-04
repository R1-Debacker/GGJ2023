using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class PrefabDocScript : MonoBehaviour
{
    [SerializeField] public RectTransform rect;
    private float lifetime;
    [SerializeField] public Image header;
    [SerializeField] public TextMeshProUGUI Name;
    [SerializeField] public Image content;
    [SerializeField] private PopUpScriptable[] possiblePopUps = null;
    [HideInInspector] public PopUpScriptable PopUp = null;
    
    private Vector3 _scale;

    private void SetPopUP()
    {
        header.color = PopUp.Malicious ? Color.red : Color.green;
        Name.text = PopUp.Name;
        content.sprite = PopUp.Content;
        //content.preserveAspect = true;
    }
    private void Awake()
    {
        PopUp = possiblePopUps[Random.Range(0, possiblePopUps.Length)];

        lifetime = 4f;
        _scale = rect.localScale;
    }

    private void Start()
    {
        SetPopUP();
        float rand_scale = Random.Range(2f, 4.5f);
        LeanTween.scale(rect, _scale * rand_scale, lifetime).setIgnoreTimeScale(true);
        Destroy(gameObject, lifetime);
        
    }

    
}
