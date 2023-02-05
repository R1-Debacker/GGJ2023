using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;




/*

"Welcome to your terminal, Mister Chase."
"What command do you wish to know more about ?"
adrianchase@hackinux :~/root help -all

"Oh, perhaps you forgot how to use your PC correctly ? Haha, just kidding.
Anyway, here are a few advices i can give you :

- Left click for basic interaction with buttons :
- Minimize/Resize/Close on the right corner of any window
    - Launch any app in the toolbar of your screen

    - Right click for special interaction : 
- Inspect a html file in the Explorer

    - You can use your keyboard to press keys if you need to type a name or a password

    - "Enjoy !"
*/

public class AffichageCommandes : MonoBehaviour
{
    [SerializeField, TextArea] private string finalText;
    [SerializeField] private GameObject rectCursor;
    
    private int index;
    private string actualText = "";
    private float _cooldown = 0.12f;
    
    //---------------------------------------------------------------------------//
    private string _greenText = "adrianchase@hackinux :~/root";
    
    private string _redText1 = "Left click";
    private string _redText2 = "Right click";
    private string _redText3 = "keyboard";
    private string _redText4 = "toolbar";
    
    private string _yellowText1 = "Minimize/Resize/Close";
    private string _yellowText2 = "Inspect";
    private string _yellowText3 = "type a name or a password";
    private string _yellowText4 = "Launch";
    //---------------------------------------------------------------------------//
    
    public TextMeshProUGUI logTextBox;
    public float specialPause = 0.05f;
    public float normalPause = 0.00001f;
    
    //string sentence = "Hello (username)" ;
    //string output = sentence.Replace( "(username)", "Bob" ) ;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(Cooldown());
    }

    private void ReproduceText()
    {
        //if not readied all letters
        if (index < finalText.Length)
        {
            //get one letter
            var letter = finalText[index];

            //Actualize on screen
            logTextBox.text = Write(letter);

            //set to go to the next
            index += 1;
            
            logTextBox.text = logTextBox.text.Replace(_greenText, "<color=green>adrianchase@hackinux :~/root</color>");
            logTextBox.text = logTextBox.text.Replace(_redText1, "<color=red>Left click</color>");
            logTextBox.text = logTextBox.text.Replace(_redText2, "<color=red>Right click</color>");
            logTextBox.text = logTextBox.text.Replace(_redText3, "<color=red>keyboard</color>");
            logTextBox.text = logTextBox.text.Replace(_redText4, "<color=red>toolbar</color>");
            logTextBox.text = logTextBox.text.Replace(_yellowText1, "<color=yellow>Minimize/Resize/Close</color>");
            logTextBox.text = logTextBox.text.Replace(_yellowText2, "<color=yellow>Inspect</color>");
            logTextBox.text = logTextBox.text.Replace(_yellowText3, "<color=yellow>type a name or a password</color>");
            logTextBox.text = logTextBox.text.Replace(_yellowText4, "<color=yellow>Launch</color>");
            

            StartCoroutine(PauseBetweenChars(letter));
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    private string Write(char letter)
    {
        actualText += letter;
        return actualText;
    }

    private IEnumerator PauseBetweenChars(char letter)
    {
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(specialPause);
                ReproduceText();
                yield break;
            case ',':
                yield return new WaitForSeconds(specialPause);
                ReproduceText();
                yield break;
            case ' ':
                yield return new WaitForSeconds(specialPause);
                ReproduceText();
                yield break;
            default:
                yield return new WaitForSeconds(normalPause);
                ReproduceText();
                yield break;
        }
    }
    
    IEnumerator Cooldown()
    {
        logTextBox.text = "Loading...";
        
        rectCursor.SetActive(false);
        yield return new WaitForSeconds(_cooldown);
        rectCursor.SetActive(true);
        yield return new WaitForSeconds(_cooldown);
        rectCursor.SetActive(false);
        yield return new WaitForSeconds(_cooldown);
        rectCursor.SetActive(true);
        yield return new WaitForSeconds(_cooldown);
        rectCursor.SetActive(false);
        yield return new WaitForSeconds(_cooldown);
        
        
        ReproduceText();
    }
}

