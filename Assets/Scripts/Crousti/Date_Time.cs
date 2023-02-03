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
        date.text = System.DateTime.Now.ToString("dddd dd MMMM yyyy");
        hour.text = System.DateTime.Now.ToString("HH:mm");
    }
}
