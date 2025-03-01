using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    public Button gorus;
    public Button anlas;
    public Button anlaskes;

    private void Start()
    {
        Debug.Log(30);
        gorus.onClick.AddListener(()=>buttonDisable());
        anlas.onClick.AddListener(() => buttonDisableLonger());
        anlaskes.onClick.AddListener(() => buttonDisable());
    }
    public void buttonDisable()
    {
        Debug.Log(40);
        gorus.interactable = false;
        anlas.interactable = false;
        anlaskes.interactable=false;
        Invoke(nameof(buttonDelay), 3f); 

    }
    public void buttonDisableLonger()
    {
        Debug.Log(40);
        gorus.interactable = false;
        anlas.interactable = false;
        anlaskes.interactable = false;
        Invoke(nameof(buttonDelay), 6f);

    }
    private void buttonDelay()
    {
        Debug.Log(50);
        gorus.interactable=true;
        anlas.interactable=true;
        anlaskes.interactable=true;



    }

}
 