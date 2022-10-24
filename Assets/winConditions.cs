using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winConditions : MonoBehaviour
{
    public Text winText;
    public void Start()
    {
        winText = GetComponent<Text>();
        
    }
    public void playerWin()
    {
        if (winText != null)
        {
            winText.text = "Player has won";
            showText();

        }
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
        if (winText != null)
        {
            winText.text = "Enemy has won";
            showText();
        }
    }
}
