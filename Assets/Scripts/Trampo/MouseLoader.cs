using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLoader : MonoBehaviour
{
    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void PopForSecond()
    {
        gameObject.SetActive(true);
        Cursor.visible = false;
        StartCoroutine(PopCoroutine());
    }

    private IEnumerator PopCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
}
