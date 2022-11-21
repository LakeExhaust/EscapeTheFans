using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class GameManger : MonoBehaviour
{

    // Start is called before the first frame update

    public int counter = 0;
    public bool value = false;
    public BigFan bigFan;
    public Enemy enemy;
    public Spawmer spawmer;
    public Water water;
    public Shooting shooting;
    public winConditions winText;
    public Player player;
    public bool spawnedEnemies = false;
    bool playerWon = false;
    bool enemyWon = false;

    bool colorHasChanged = false;

    public float countdown = 0;
    public bool enemyHit = false;
    public float timerHasNotRunOut = 0;
    SpriteRenderer spr;
    public screenShake cam;

    public AudioClip damage;
    AudioSource src;

    public GrenadeHandler gh;

    public Cooldown cl;

    public bool hasReallyHit = false;
    public EnemyWeapon ew;
    void Start()
    {
        bigFan = GameObject.FindGameObjectWithTag("BigFan").GetComponent<BigFan>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        spawmer = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawmer>();
        water = GameObject.FindGameObjectWithTag("Water").GetComponent<Water>();
        shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
        //scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        winText = GameObject.FindGameObjectWithTag("winText").GetComponent<winConditions>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<screenShake>();
        cl = GameObject.FindGameObjectWithTag("Cooldown").GetComponent<Cooldown>(); 
        ew = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyWeapon>();
        src = GetComponent<AudioSource>();
        src.clip = damage;
        
        water.hideWater();

        winText.hideText();
    }


    // Update is called once per frame


    void Update()
    {
        resetGame();

        //   Shield();

        StartCoroutine(playShield());

       
       

    }

    public void FixedUpdate()
    {
        startPemaence();
    }




    public Player getPlayer()
    {
        if (player == null)
        {

        }
        return player;
    }


    public bool isTrue()
    {


        if (counter == 3)
        {
            Debug.Log("You have one dead");
            value = true;
        }
        else
        {
            value = false;
        }
        return value;
    }



    public void increaseDead()
    {
        counter++;
        Debug.Log("The death has been increased" + counter);
    }




    public Enemy GetEnemy()
    {
        return enemy;
    }
    public BigFan GetBigFan()
    {
        return bigFan;
    }

    public bool isBigFan()
    {
        return bigFan.isBigDead();
    }

    public bool isEnemy()
    {
        return enemy.isEnemyDead();
    }
    public void spawnEnemy(int amount)
    {
        spawnedEnemies = true;
        spawmer.itemToSpawn(amount);
    }

    public void getWater()
    {
        water.pickUp();
    }
    public void hideWater()
    {
        water.hideWater();
    }

    public bool checkWater()
    {
        return water.isWater();
    }
    public bool hasTimeRunOut()
    {
        bool value = false;
        if (water.timer < 0)
        {
            value = true;

        }
        return value;
    }

    public bool hasFired()
    {
        return shooting.isFired();
    }

    public int getCounter()
    {
        return counter;
    }

    public void increaseSpeed()
    {
        enemy.increaseSpeed();

    }

    public void playerWin()
    {
        playerWon = true;
        winText.playerWin();
          
    }

    public void enemyWin()
    {
       
        enemyWon = true;
        winText.enemyWin();
    }

    public bool isPlayerDead()
    {
        bool value = false;
        if (player.health <= 0)
        {
            value = true;
        }
        return value;
    }
    public bool hasSpawned()
    {
        return spawnedEnemies;
    }

    public void changeColor(GameObject target)
    {
        spr = target.GetComponent<SpriteRenderer>();
        spr.color = Color.red;



    }

    public void changeBlue(GameObject target)
    {
        spr = target.GetComponent<SpriteRenderer>();
        spr.color = Color.blue;



    }




    public void revertColor()
    {
        if (enemyHit == true && spr != null)
        {
            spr.color = Color.Lerp(spr.color, Color.white, Time.deltaTime / 0.5f);

        }
    }

    public void playerRevertColor()
    {
        if (spr != null)
        {
            spr.color = Color.Lerp(spr.color, Color.white, Time.deltaTime / 0.5f);

        }
    }

    public int numberOfEnemies()
    {
        return enemy.getNumberOfEnemies();
    }

    public void resetGame()
    {

        if (playerWon == true && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarting game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (enemyWon == true && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restarting game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GetShake()
    {
        StartCoroutine(cam.Shake(.15f, 0.01f));
    }

    public void playDamage()
    {
        src.Play();
    }

  public void Shield()

    {
      if(hasReallyHit==true && enemy.isEnemyDead()==false)
        {
            enemy.playShield();
            Debug.Log("SHIELDISON");
        } else if(hasReallyHit == false && enemy.isEnemyDead() == false)
        {
            enemy.stopShied();
            Debug.Log("SHIELDISOFF");
        }
       
            
        
    }

    public IEnumerator playShield()
    {

        if(hasReallyHit==true)
        {
          
            enemy.playShield();
            Debug.Log("SHIELDISON");
          

        } else if(hasReallyHit==false)
        {
            yield return new WaitForSeconds((float)0.5F);
            enemy.stopShied();
            Debug.Log("SHIELDISOFF");
        }
    }

    public bool hasHitEnemy()
    {
       return gh.hasHit();
    }

    public void playAnim()
    {
        gh.playAnim();
    }

    public void startPemaence()
    {
        enemy.startPemance();       
    }
   public bool hasDied()
    {
        return enemy.hasDied;
    }

    public void startPlayerPermance()
    {
        player.onDeath();
    }

    public bool getNormalBullet()
    {
        return shooting.isNormalBulletFired();
    }

    public void setCoolDown(float cooldown)
    {
           cl.setCoolDown(cooldown);    
    }

    public bool isItCoolDown()
    {
        return cl.IsItCoolDown();
    }

    public void throwGrenadeBack()
    {
        ew.throwGrenade();
        Debug.Log("Throws the grenade back");

    }
}