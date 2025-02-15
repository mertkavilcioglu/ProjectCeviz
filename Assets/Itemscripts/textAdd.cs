using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;
using TMPro;

public class textAdd : MonoBehaviour
{
   
    public TMP_Text text1;
    private int number;
    
    public void AddText()
    {



        if (!int.TryParse(text1.text, out number))
        {
            number = 0;
        }
        number += 1500;
        text1.text = number.ToString();
        
    }
    public void MinusText()
    {



        if (!int.TryParse(text1.text, out number))
        {
            number = 0;
        }
        number -= 1500;
        text1.text = number.ToString();



    }


   
    
    void Update()
    {
        
    }
}
