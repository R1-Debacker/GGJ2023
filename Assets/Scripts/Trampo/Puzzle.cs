using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private PuzzleImage[] pieces = null;


    private Dictionary<Vector2, PuzzleImage> places = new Dictionary<Vector2, PuzzleImage>();
    private Vector2[] positions = new Vector2[16];

    private const float spacing = 100f;

    public Vector2[] Positions { get => positions; set => positions = value; }

    public void StartPuzzle()
    {
        SetPlaces();
    }

    private void SetPlaces()
    {
        for (int j = 0; j < 4; j++)
        {
            for (int k = 0; k < 4; k++)
            {
                positions[j * 4 + k] = new Vector2(-50 - k * spacing, 50 + j * spacing);
            }
        }
        for (int i = 0; i < pieces.Length; i++)
        {
            places[positions[i]] = pieces[i];
            Vector2 pos = new Vector2(Random.Range(-350f, -50f), Random.Range(50f, 350f));
            pieces[i].GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    public bool IsEnded()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (Vector2.Distance(places[positions[i]].GetComponent<RectTransform>().anchoredPosition, positions[i]) > 20f)
            {
                return false;
            }
        }
        End();
        return true;
    }

    private void End()
    {
        foreach (PuzzleImage image in pieces)
        {
            image.gameObject.layer = LayerMask.NameToLayer("UI");
        }
    }

}
