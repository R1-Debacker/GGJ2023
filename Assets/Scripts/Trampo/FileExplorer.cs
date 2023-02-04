using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FileExplorer : MonoBehaviour, IPointerClickHandler
{

    
    [SerializeField] private GameObject content = null;
    [SerializeField] private bool canInspect = false;
    [SerializeField] private GameObject inspectButton = null;
    private bool isShowed = false;

    [SerializeField] private bool revealed = true;

    public bool Revealed { get => revealed; set => revealed = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && canInspect)
        {
            inspectButton.SetActive(true);
        }
    }

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
