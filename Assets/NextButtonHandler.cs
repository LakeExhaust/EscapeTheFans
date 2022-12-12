using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NextButtonHandler : MonoBehaviour
{
    public static bool hasClicked = false;
    public static int numberClicks = 0;

    public void Update()
    {
       
    }

    public void onClick()
    {
        hasClicked = true;
        Debug.Log("Clicked Next");
        numberClicks++;
    }

    public bool getClicked() { return hasClicked; }

    public void setClicked(bool state)
    {
        hasClicked = state; 
    }

    public int clicks()
    {
        return numberClicks;    
    }
}
