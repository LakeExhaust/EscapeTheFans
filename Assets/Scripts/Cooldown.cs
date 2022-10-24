using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    private float coolDown;
    private Text coolText;
    private bool isCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        coolText = GetComponent<Text>();  
        
       
    }

    // Update is called once per frame
    void Update()
    {
        applyCoolDowntTimer();
    }

    public void setCoolDown(float cooldown)
    {
        this.coolDown = cooldown;

    }

    public void applyCoolDowntTimer()
    {
      
        coolDown -= Time.deltaTime;
        isCoolDown = true;
       
        coolText.text = "COOLDOWN ALERT" + Mathf.RoundToInt(coolDown).ToString();  
        if(coolDown <0)
        {
            isCoolDown=false;   
            coolText.text = "You're cooldown is over";
        
              
        }
    }

    public bool IsItCoolDown()
    {
        
        return isCoolDown;
    }
}
