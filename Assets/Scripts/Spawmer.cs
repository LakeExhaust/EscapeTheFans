using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Spawmer : MonoBehaviour
{
    // Start is called before the first frame update

   
    public GameObject objectToSpawn;

    private GameObject item;

    public void itemToSpawn(int amount)
    {
        if (objectToSpawn != null)
        {
            for (int i = 0; i < amount; i++)
            {
                item = Instantiate(objectToSpawn, transform.position, transform.rotation);

            }
        }
    }

}
