using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagPole : MonoBehaviour
{
    public Animation animationClip;
    public Text winText;
    GameManger gm;
    AudioSource audioSource;
    public AudioClip clip; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            Debug.Log("You win");
            GetComponent<Animator>().Play("flagRaise");
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log(audioSource.isPlaying);    
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Click E"); 
        }
    }
}
