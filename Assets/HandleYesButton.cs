using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleYesButton : MonoBehaviour
{
    public static bool hasClicked = false;


    public void Update()
    {
        hasClicked = false;
    }

    public void onClick()
    {
        hasClicked = true;
        Debug.Log("Hi");
    }

    public bool getClicked() { return hasClicked; }    


}
