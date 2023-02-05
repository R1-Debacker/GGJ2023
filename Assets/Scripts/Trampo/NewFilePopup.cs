using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFilePopup : MonoBehaviour
{
    public void Pop()
    {
        gameObject.SetActive(true);
        StartCoroutine(PopCoroutine());
    }

    private IEnumerator PopCoroutine()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

    }
}
