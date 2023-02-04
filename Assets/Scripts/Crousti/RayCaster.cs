using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private Player player = null;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    private int _score = 0;

    void Start()
    {
        //Fetch the Event System from the Scene
        m_EventSystem = raycaster.GetComponent<EventSystem>();
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                PrefabDocScript doc = result.gameObject.GetComponent<PrefabDocScript>();
                if (doc)
                {
                    if (doc.PopUp.Malicious && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        _score = _score == 0 ? 0 : _score - 1;
                        Destroy(result.gameObject);
                    }
                    else if (!doc.PopUp.Malicious && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        _score++;
                        Destroy(result.gameObject);
                    }
                    else if (!doc.PopUp.Malicious && Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        _score = _score == 0 ? 0 : _score - 1;
                        Destroy(result.gameObject);
                    }
                    else if (doc.PopUp.Malicious && Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        _score++;
                        Destroy(result.gameObject);
                    }
                    player.ScoreText.text = "score : " + _score.ToString();
                    break;
                }
                
            }
        }
    }
}
