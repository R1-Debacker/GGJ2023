using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject prefabDoc;
    [SerializeField] private RectTransform background;
    [SerializeField] private Transform parentPanel = null;
    [SerializeField] private GameWindow window = null;
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    [SerializeField] private int minScore = 5;
    [SerializeField] private GameObject retryButton = null;

    public UnityEvent OnGameEnded = null;

    private bool isPlaying = false;

    public float maxSpeed = 15.0f;
    public float minSpeed = 3.0f;

    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }

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
        int.TryParse(scoreText.text, out int score);
        if (score >= minScore)
        {
            OnGameEnded?.Invoke();
        }
        else
        {
            retryButton.SetActive(true);
        }
        isPlaying=false;
    }

    public void Retry()
    {
        scoreText.text = "0";
        window.GetComponent<RayCaster>().Score = 0;
        StartAim();
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
}
