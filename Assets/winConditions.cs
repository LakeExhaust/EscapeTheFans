using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winConditions : MonoBehaviour
{
    public Text winText;
    public AudioClip youWin;
    public AudioClip youLoose;
    public AudioSource src;
    public void Start()
    {
        winText = GetComponent<Text>();
        src = GetComponent<AudioSource>();
       
    }
    public void playerWin()
    {
       
      
            
            winText.text = "Player has won";
            showText();
            src.clip = youWin;
            src.Play();
            Debug.Log(src.isPlaying + "w");

        
    }

    public Text getWinText()
    {
        return winText; 
    }

    public void hideText()
    {
       gameObject.SetActive(false);
    }

    public void showText()
    {
        gameObject.SetActive(true);
    }

    public void enemyWin()
    {
        
            src.clip = youLoose;
            src.Play();
            winText.text = "Enemy has won";
            showText();
        
    }
}
