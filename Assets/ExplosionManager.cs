using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{

    public AudioSource src;
    public AudioClip clip;
    public GameManger gm;
    // Start is called before the first frame update
    void Start()
    {
        src.clip = clip;    
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        playExplosion();
        
    }

    public void playExplosion()
    {

        if (gm.hasHitEnemy() == true)
        {
            Debug.Log("This this");
            gm.playAnim();
            src.Play();
        }
    }
}
