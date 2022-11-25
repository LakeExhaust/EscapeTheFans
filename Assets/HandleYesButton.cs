using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleYesButton : MonoBehaviour
{
    public static bool clicked = false;

    void LateUpdate()
    {
        clicked = false;
    }

    public void Click()
    {
        clicked = true;
        Debug.Log("Hi");
    }

    public bool getClicked() { return clicked; }    
}
