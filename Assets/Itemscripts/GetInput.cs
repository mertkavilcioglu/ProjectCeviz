using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    public TMP_InputField tmpInputField;
    
    private int textValue;
    

    public int ReadInput()
    {
        if (int.TryParse(tmpInputField.text, out textValue))
        {
            return textValue;
            
        }
        else
        {
            Debug.Log("Invalid number");
            return 0;
        }
        
    }
    
        void Start()
        {
            if (tmpInputField != null)
            {
                tmpInputField.textComponent.color = Color.black; 
            }
        }
    

}
