using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyFlag : MonoBehaviour
{
    public Animation animationClip;
    GameManger gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy win");
            GetComponent<Animator>().Play("wavingFlag");
            gm.enemyWin();

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

    }

    // Update is called once per frame

}
