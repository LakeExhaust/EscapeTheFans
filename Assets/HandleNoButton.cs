using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNoButton : MonoBehaviour
{
    public static bool Noclicked = false;

    void LateUpdate()
    {
        Noclicked = false;
    }

    public void Click()
    {
        Noclicked = true;
        Debug.Log("NOO");
    }
    public bool getClicked() { return Noclicked; }
}
