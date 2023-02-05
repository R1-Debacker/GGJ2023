using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;
    private Vector2 hotSpot;
    private CursorMode _cursorMode = CursorMode.Auto;


    public static GameManager instance;

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            hotSpot = new Vector2(cursorTexture.width / 2, 0);
            Cursor.SetCursor(cursorTexture, hotSpot, _cursorMode);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            GetComponent<AudioSource>().Play();
        }

        if (Input.mousePosition.x < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.x > Screen.width)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.y < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.mousePosition.y > Screen.height)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
