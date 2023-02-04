using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private Vector2 hotSpot;
    [SerializeField] private GameObject prefabDoc;
    [SerializeField] private RectTransform background;
    [SerializeField] private Transform parentPanel = null;
    [SerializeField] private GameWindow window = null;
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    private bool isPlaying = false;
    private CursorMode _cursorMode = CursorMode.Auto;

    public float maxSpeed = 15.0f;
    public float minSpeed = 3.0f;

    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }

    public void Awake()
    {
        //hotSpot = new Vector2(cursorTexture.width / 2, 0);
        //Cursor.SetCursor(cursorTexture, hotSpot, _cursorMode);
        
    }

    public void StartAim()
    {
        isPlaying = true;
        StartCoroutine(SpawningSquares());
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator SpawningSquares()
    {
        yield return new WaitForSeconds(2f);
        while (isPlaying)
        {
            var temp = Instantiate(prefabDoc, Vector3.zero, Quaternion.identity, parentPanel);

            PrefabDocScript script = temp.GetComponent<PrefabDocScript>();
            temp.GetComponent<RectTransform>().sizeDelta *= window.IsStretched ? 1f : 0.75f;

            RectTransform tempRect = script.rect;
            
            
            tempRect.anchoredPosition = new Vector2(Random.Range(-background.rect.width/2 + 50f, background.rect.width / 2 -50f), Random.Range(-background.rect.height / 2 + 50f, background.rect.height / 2 - 50f));
            temp.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private void End()
    {
        isPlaying=false;
    }

    private IEnumerator TimerCoroutine()
    {
        float timer = 20f;
        float elapsedTime = 0f;
        while (elapsedTime < timer)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = "Temps restant : " + (timer - elapsedTime).ToString("F0") + "s";
            yield return new WaitForEndOfFrame();
        }
        End();
        yield break;
    }

    private void Update()
    {
        
        //if (Input.mousePosition.x < 0)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}
        //if (Input.mousePosition.x > Screen.width)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}
        //if (Input.mousePosition.y < 0)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}
        //if (Input.mousePosition.y > Screen.height)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}


    }
}
