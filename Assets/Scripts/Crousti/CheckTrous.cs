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
    private List<List<string>> mots = new List<List<string>>();

    public UnityEvent OnEnded = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        indices[0] = indice1;
        indices[1] = indice2;
        indices[2] = indice3;
        indices[3] = indice4;
        indices[4] = indice5;

        List<string> strings1 = new List<string>();
        strings1.Add("Clavel");
        mots.Add(strings1);
        
        List<string> strings2 = new List<string>();
        strings2.Add("Stanislas");
        mots.Add(strings2);
        
        List<string> strings3 = new List<string>();
        strings3.Add("Nancy");
        mots.Add(strings3);
        
        List<string> strings4 = new List<string>();
        strings4.Add("Lithuanian");
        strings4.Add("lithuanian");
        mots.Add(strings4);
        
        List<string> strings5 = new List<string>();
        strings5.Add("ZAC");
        strings5.Add("Zac");
        strings5.Add("zac");
        strings5.Add("Z.A.C");
        mots.Add(strings5);
        
    }

    private void Update()
    {
        //if (window.IsStretched)
        //{
        //    transform.localScale = new Vector2(1.4f, 1.4f);
        //}
        //else
        //{
        //    transform.localScale = Vector2.one;
        //}
    }

    public void Check()
    {
        bool isEnded = true;
        for (int i = 0; i < indices.Length; i++)
        {
            if (mots[i].Contains(indices[i].text))
            {
                indices[i].textComponent.fontStyle = FontStyles.Bold;
                indices[i].interactable = false;
            }
            else
            {
                isEnded = false;
                if (!string.IsNullOrEmpty(indices[i].text))
                {
                    indices[i].text = string.Empty;
                }
                
            }
        }
        if (isEnded) OnEnded.Invoke();
    } 
}
