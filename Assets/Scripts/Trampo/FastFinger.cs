using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FastFinger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TMP_InputField inputField = null;
    [SerializeField] private TextMeshProUGUI textToType = null;
    [SerializeField] private List<string> possibleTexts = null;

    private int score = 0;

    private void Start()
    {
       StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }

    public void Validate(string attempt)
    {
        if (attempt == textToType.text)
        {
            score++;
            possibleTexts.Remove(textToType.text);
            if (possibleTexts.Count == 0)
            {
                End();
            }
            else
            {
                textToType.text = possibleTexts[Random.Range(0, possibleTexts.Count)];
                inputField.text = "";
            }
        }
        else
        {
            //inputField.text = "";
        }
        scoreText.text = "Score : " + score;
    }

    private void End()
    {
    }

    private IEnumerator TimerCoroutine()
    {
        float timer = 30f;
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
