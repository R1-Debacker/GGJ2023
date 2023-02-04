using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 hotSpot;
    [SerializeField] private GameObject prefabDoc;
    
    private int _score = 0;
    private Canvas _canvas;
    private  CursorMode _cursorMode = CursorMode.Auto;

    public float maxSpeed = 15.0f;
    public float minSpeed = 3.0f;
    

    public void Awake()
    {
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, _cursorMode);
        _canvas = GetComponentInParent<Canvas>();
        
    }

    private void Start()
    {
        StartCoroutine(SpawningSquares());
    }

    IEnumerator SpawningSquares()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            var temp = Instantiate(prefabDoc, Vector3.zero, Quaternion.identity, _canvas.transform);

            PrefabDocScript script = temp.GetComponent<PrefabDocScript>();

            float lifetime = script.lifetime;
            RectTransform tempRect = script.rect;
            
            Destroy(temp,lifetime);
            
            tempRect.anchoredPosition = new Vector2(Random.Range(-355, 355), Random.Range(-210f, 210f));
            temp.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
    
    private void Update()
    {
        
        if (Input.mousePosition.x < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.x > Screen.width)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.y < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.y > Screen.height)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }

       
        Debug.Log(_score);

    }
}
