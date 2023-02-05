using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Date_Time : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI date;
    [SerializeField] private TextMeshProUGUI hour;
    
    public void Start()
    {
        var culture = new System.Globalization.CultureInfo("en-US");
        date.text = System.DateTime.Now.ToString("dddd, MMMM dd",culture);
        hour.text = System.DateTime.Now.ToString("HH:mm",culture);
        
    }
}
