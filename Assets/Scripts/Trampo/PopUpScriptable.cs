using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PopUp/New PopUp", fileName = "New PopUp")]
public class PopUpScriptable : ScriptableObject
{
    public bool Malicious = false;
    public string Name = "";
    public Sprite Content = null;
}
