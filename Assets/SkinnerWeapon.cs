using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinnerWeapon : MonoBehaviour
{
    public Text qr;
    public Button yesButton;
    public Button noButton;
    public GameManger gm;
    public string buttonName;
    bool clickedYes;
    bool clickedNo;
    public float timeRemaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        qr = GameObject.FindGameObjectWithTag("Question").GetComponent<Text>();
        qr.gameObject.SetActive(false);
        yesButton = GameObject.FindGameObjectWithTag("YesButton").GetComponent<Button>();
        noButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        noButton.gameObject.SetActive(false);   
        yesButton.gameObject.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();



    }

    // Update is called once per frame
    void Update()
    {
      //  hasKilledEnoughEnemies();
    }

    public void hasKilledEnoughEnemies()
    {
        Time.timeScale = 0.0f;
        qr.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);   
        noButton.gameObject.SetActive(true);
        clickedYes = yesButton.GetComponent<HandleYesButton>().getClicked();
        clickedNo = noButton.GetComponent<HandleNoButton>().getClicked();
        if (clickedYes==true)
        {
            Debug.Log("Player has cliked on the yes Button");
            noButton.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(false);
            qr.gameObject.SetActive(false);
            gm.skinnerOn();
            Time.timeScale = 1f;
            
        } else if(clickedNo==true)
        {

            Debug.Log("Player has cliked on the no Button");
            noButton.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(false);
            qr.gameObject.SetActive(false);
            gm.skinnerOff();
            Time.timeScale = 1f;
        }
       
      
    }

}
