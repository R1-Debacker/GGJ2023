using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crousti
{
    public class MotDePasse : MonoBehaviour
    {

        private string _motDePasse;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI textDisplay;

        public void Validation()
        {
            if (_motDePasse == "racines" || _motDePasse == "Racines" || _motDePasse == "RACINES" || _motDePasse == "roots" || _motDePasse == "Roots" || _motDePasse == "ROOTS")
            {
                textDisplay.text = "Mot de passe correct";
                textDisplay.color = Color.green;
            }
            else
            {
                textDisplay.text = "Mot de passe incorrect";
                textDisplay.color = Color.red;
            }
            inputField.text = "";
        }
        
        private void Start()
        {
            inputField.contentType = TMP_InputField.ContentType.Password;
            inputField.asteriskChar = '*';
            _motDePasse = inputField.text;
            
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Validation();
                inputField.Select();
                inputField.ActivateInputField();
                
            }
        }
    }
}
