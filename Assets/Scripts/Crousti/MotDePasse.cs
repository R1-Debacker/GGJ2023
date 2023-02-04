using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            _motDePasse = inputField.text;
            if (_motDePasse == "racines" || _motDePasse == "Racines" || _motDePasse == "RACINES" || _motDePasse == "roots" || _motDePasse == "Roots" || _motDePasse == "ROOTS")
            {
                SceneManager.LoadScene("MainScene");
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
