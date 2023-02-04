using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UrlChecker : MonoBehaviour
{
    [SerializeField] private string aimUrl = string.Empty;

    public UnityEvent OnGoodUrl;

    public void CheckUrl(string url)
    {
        if (url == aimUrl)
        {
            OnGoodUrl?.Invoke();
        }
    }
}
