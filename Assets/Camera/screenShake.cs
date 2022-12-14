using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    GameManger gm;
  
    public   IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalpos =transform.position;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f,1f)*magnitude;
            float y =Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(x, y, orignalpos.z);
            elapsed += Time.deltaTime;      
            yield return null;  
        }
         transform.position = orignalpos;
    }
   
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
    }
   
}
