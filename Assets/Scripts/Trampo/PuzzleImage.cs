using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PuzzleImage : MonoBehaviour
{
    [SerializeField] private Puzzle puzzle = null;

    private Image image = null;
    public void PlaceImage()
    {
        foreach (Vector2 position in puzzle.Positions)
        {
            if (Vector2.Distance(GetComponent<RectTransform>().anchoredPosition, position) < 20f)
            {
                GetComponent<RectTransform>().anchoredPosition = position;
                transform.SetAsFirstSibling();
                puzzle.IsEnded();
                return;
            }
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

}
