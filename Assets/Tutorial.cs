using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text subText;
    public Button nextBtn;
    public Text textBtn;
    public bool hasClickedFirst = false;
    public bool hasClickedSecond = false;
    public bool hasClicked;
    public int numclicks;
    public bool hasClickedThird = false;
    public bool hasClickedFourth = false;
    public Canvas tutCanvas;
    public Text tutTitle;
    public Image tutColor;
    // Start is called before the first frame update
    void Start()
    {
        subText = GameObject.FindGameObjectWithTag("Subtext").GetComponent<Text>();
        nextBtn = GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>();   
        textBtn = GameObject.FindGameObjectWithTag("ButtonText").GetComponent<Text>();
        tutCanvas = GameObject.FindGameObjectWithTag("TutorialCanvas").GetComponent<Canvas>();
        tutColor = GameObject.FindGameObjectWithTag("TutorialColor").GetComponent<Image>();    
        tutTitle = GameObject.FindGameObjectWithTag("TutorialTitle").GetComponent<Text>();

    }

    public void onTutorial()
    {
        Time.timeScale = 0;
        hasClicked = nextBtn.GetComponent<NextButtonHandler>().getClicked();
        numclicks = nextBtn.GetComponent<NextButtonHandler>().clicks();
        Debug.Log(hasClicked);

        if (hasClicked==true && numclicks==1)
        {
          
            Debug.Log("Its ture");
            hasClickedFirst = true; 
            subText.text = "You navigate by the WWASD keys and shoot using your left mouse button.";

        } else if(hasClickedFirst == true && numclicks==2)
        {
            hasClickedSecond= true; 
            subText.text = "Your goal is to navigate to other side of the level to raise the flag or kill all the enemies";
        } else if(hasClickedSecond==true && numclicks==3)
        {
            hasClickedThird = true;
            subText.text = "There will be some UI incidating the score, cooldown timer and healthbar";
        } else if(hasClickedThird==true && numclicks==4)
        {
            subText.text = "Through performing certain actions you will be rewarded";
            textBtn.text = "Done";
            hasClickedFourth = true;
        } else if(hasClickedFourth==true && numclicks==5)
        {
            nextBtn.gameObject.SetActive(false);        
            subText.gameObject.SetActive(false);    
            textBtn.gameObject.SetActive(false);    
            tutCanvas.gameObject.SetActive(false); 
            tutColor.gameObject.SetActive(false);      
            tutTitle.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
           // subText.text = "Your goal is to navigate to other side of the level to raise the fLag or kill all the enemies";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
