using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SCR_UiDrag : MonoBehaviour
{
    public GameObject ui_canvas;
    public LayerMask validLayers;
    GraphicRaycaster ui_raycaster;
    PointerEventData click_data;
    List<RaycastResult> click_results;

    [HideInInspector] public List<GameObject> Clicked_elements;

    bool dragging = false;

    Vector3 mouse_position;
    Vector3 previous_mouse_position;


    void Start()
    {
        ui_raycaster = ui_canvas.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
        Clicked_elements = new List<GameObject>();
    }

    void Update()
    {
        MouseDragUi();
    }

    void MouseDragUi()
    {
        /** Houses the main mouse dragging logic. **/

        mouse_position = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DetectUi();
        }
        else if (Input.GetKey(KeyCode.Mouse0) && dragging)
        {
            DragElement();
        }
        else
        {
            if (dragging) EndDrag();
            dragging = false;
        }

        previous_mouse_position = mouse_position;
    }

    private void EndDrag()
    {
        foreach (GameObject go in Clicked_elements)
        {
            PuzzleImage image = go.GetComponent<PuzzleImage>();
            image.PlaceImage();
        }
    }

    void DetectUi()
    {
        /** Detect if the mouse has been clicked on a UI element, and begin dragging **/

        GetUiElementsClicked();

        if (Clicked_elements.Count > 0)
        {
            dragging = true;
        }
    }

    void GetUiElementsClicked()
    {
        /** Get all the UI elements clicked, using the current mouse position and raycasting. **/

        click_data.position = mouse_position;
        click_results.Clear();
        ui_raycaster.Raycast(click_data, click_results);

        GameObject selectedObject = null;
        foreach (RaycastResult result in click_results)
        {
            if (validLayers == (validLayers | (1 << result.gameObject.layer)))
            {
                selectedObject = result.gameObject;
                selectedObject.transform.SetAsLastSibling();
                break;
            }
        }
        if (selectedObject == null)
        {
            Clicked_elements.Clear();
        }
        else
        {
            if (!Clicked_elements.Contains(selectedObject))
            {
                Clicked_elements.Clear();
                Clicked_elements.Add(selectedObject);
            }
        }
    }

    void DragElement()
    {
        /** Drag a UI element across the screen based on the mouse movement. **/
        foreach (GameObject drag_element in Clicked_elements)
        {
            RectTransform element_rect = drag_element.GetComponent<RectTransform>();

            Vector2 drag_movement = mouse_position - previous_mouse_position;
            if (drag_movement.magnitude > 100) return;
            element_rect.anchoredPosition = element_rect.anchoredPosition + drag_movement;
        }
        
    }

}