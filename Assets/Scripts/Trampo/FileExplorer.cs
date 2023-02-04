using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileExplorer : MonoBehaviour
{
    [SerializeField] private GameObject content = null;
    private bool isShowed = false;

    public void ShowFileContent()
    {
        if (!isShowed)
        {
            content.SetActive(true);
            content.transform.SetAsLastSibling();
        }
        else
        {
            content.SetActive(false);
        }
        isShowed = !isShowed;
    }
}
