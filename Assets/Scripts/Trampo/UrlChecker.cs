using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UrlChecker : MonoBehaviour
{
    [SerializeField] private string aimUrl = string.Empty;
    [SerializeField] private GameObject error = null;
    [SerializeField] private GameObject file = null;
    [SerializeField] private GameObject shortcuts = null;
    [SerializeField] private GameObject spinner = null;

    private bool isChecking = true;

    public UnityEvent OnGoodUrl;

    public bool IsChecking { get => isChecking; set => isChecking = value; }

    public void CheckUrl(string url)
    {
        if (isChecking)
        {
            shortcuts.SetActive(false);
            file.SetActive(false);
            error.SetActive(false);
            spinner.SetActive(true);
            StartCoroutine(LoadURL(url));
        }
    }

    private IEnumerator LoadURL(string url)
    {
        yield return new WaitForSeconds(1f);
        spinner.SetActive(false);
        if (url == aimUrl)
        {
            OnGoodUrl?.Invoke();
        }
        else
        {
            shortcuts.SetActive(false);
            file.SetActive(false);
            error.SetActive(true);
        }
    }
}
