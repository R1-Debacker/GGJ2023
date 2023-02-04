using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderExplorer : MonoBehaviour
{
    [SerializeField] private Transform folderContent = null;
    [SerializeField] private float fileHeight = 0f;
    private RectTransform rect = null;
    private float height = 0f;
    private bool isDropDown = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        height = rect.rect.height;
    }

    public void ShowFolderContent()
    {
        int count = 0;
        foreach (Transform child in folderContent)
        {
            if (child.GetComponent<FileExplorer>())
            {
                if (child.GetComponent<FileExplorer>().Revealed)
                {
                    child.gameObject.SetActive(!isDropDown);    
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
                count++;
            }
        }
        isDropDown = !isDropDown;
        float newHeight = 0f;
        if (isDropDown)
        {
            newHeight = height + count * fileHeight;
        }
        else
        {
            newHeight = height;
        }
        rect.sizeDelta = new Vector2(rect.rect.width, newHeight);
    }
}
