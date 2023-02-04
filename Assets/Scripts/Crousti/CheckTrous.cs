using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckTrous : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField indice1;
    [SerializeField] private TMP_InputField indice2;
    [SerializeField] private TMP_InputField indice3;
    [SerializeField] private TMP_InputField indice4;
    [SerializeField] private TMP_InputField indice5;
    [SerializeField] private GameWindow window;



    private TMP_InputField[] indices = new TMP_InputField[5];
    private string[] mots = new string[5];

    public UnityEvent OnEnded = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        indices[0] = indice1;
        indices[1] = indice2;
        indices[2] = indice3;
        indices[3] = indice4;
        indices[4] = indice5;
        
        mots[0] = "Clavel";
        mots[1] = "Stanislas";
        mots[2] = "Nancy";
        mots[3] = "Sylvanie";
        mots[4] = "ZAC";
    }

    private void Update()
    {
        if (window.IsStretched)
        {
            transform.localScale = new Vector2(1.4f, 1.4f);
        }
        else
        {
            transform.localScale = Vector2.one;
        }
    }

    public void Check() 
    {
        
        for (int i = 0; i < indices.Length; i++)
        {
            if (indices[i].text == mots[i])
            {
                indices[i].textComponent.fontStyle = FontStyles.Bold;
                indices[i].interactable = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(indices[i].text))
                {
                    indices[i].text = indices[i].placeholder.GetComponent<TextMeshProUGUI>().text;
                }
                return;

            }
        }
        OnEnded.Invoke();
    }
}
