using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using UnityEngine;

public class IAHealth : IA
{
    // Start is called before the first frame update
    [SerializeField]
    M4A1_Shoot M4A1;
    PlayerStats player;

    [SerializeField]
    Rigidbody bullet;

    private Animator zomb;

    void Start()
    {
        M4A1 = GameObject.Find("Eject_AR").GetComponent<M4A1_Shoot>();
        calculateNewMovementVector();
        player = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>();
        for (int i = 0; i < nbrZombies; i++)
        {
            zombiesGO.Add(zombie);
            zombieArray[i].setPosition(zombieArray[i].getMoveSpeed(), gravity);
            zombiesGO[i].transform.position = zombieArray[i].getPosition();
            zombieArray[i].setHP(200);
        }
        bullet = M4A1.bullet;


    }
    void Update()
    {
        for (int i = 0; i < zombiesGO.Count; i++)
        {
            //Debug.Log(" Position" + i + " = " + zombieArray[i].getPosition());
            if (zombieArray[i].getHP() <= 0)
            {

                //Debug.Log("Before :" + zombiesGO.Count);
                //Destroy(zombiesGO[i]);
                //zombiesGO.RemoveAt(i);
                // Debug.Log("after :" + zombiesGO.Count);
                //nbrZombies -= 1;
                /* for (int i = 0; i < zombiesGO.Count; i++)
                 {
                     if (zombieArray[i].getHP() <= 0)
                     {
                         for (int j = i + 1; j < nbrZombies; j++)
                         {
                             zombiesGO[i] = zombiesGO[j];
                             zombieArray[i] = zombieArray[j];
                         }
                     }
                 }
                 respawn(4);*/
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < zombiesGO.Count; i++)
        {
            //Debug.Log("Pos zombie : "+ i + " " + zombiesGO[i].transform.position + " pos bullet :" + collision.transform.position);
            if ((zombiesGO[i].transform.position.x > collision.transform.position.x - 10 /*zombiesGO[i].transform.position.x < col.transform.position.x + 5*/) &&
                (zombiesGO[i].transform.position.z > collision.transform.position.z - 10  /*zombiesGO[i].transform.position.z < col.transform.position.z + 5*/))
            {

                Destroy(bullet.gameObject);
                zombieArray[i].HP -= 25;

            }
        }
    }
    /*void OnTriggerEnter(Collider col)
    {
        
        /*if (col.gameObject.tag == "Wall")
        {
            
        if (col.gameObject.tag == "Bullet_M4")
        {

            player.score += 10;

            for (int i = 0; i < zombiesGO.Count; i++)
            {
                Debug.Log("Pos zombie : " + zombiesGO[i].transform.position + " pos bullet :" + col.transform.position);
                if ((zombiesGO[i].transform.position.x > col.transform.position.x - 10 zombiesGO[i].transform.position.x < col.transform.position.x + 5) &&
                    (zombiesGO[i].transform.position.z > col.transform.position.z - 10  zombiesGO[i].transform.position.z < col.transform.position.z + 5))
                {

                    Debug.Log(i);
                    Destroy(M4A1.bullet.gameObject);
                    zombieArray[i].HP -= 25;

                }
            }


        }*/


    /*if (col.gameObject.tag == "Bullet_Beret")
    {
        HP -= 15;
        player.score += 15;
    }
    if (col.gameObject.tag == "Grenade")
    {
        HP -= 50;
        player.score += 20;

    }

    for (int i = 0; i < nbrZombies; i++)
    {
        if(zombieArray[i].getHP() <=0)
        {
            //Destroy(zombieIA.zombiesGO[i]);
        }
    }
        if (HP <= 0)
    {

       //StartCoroutine(dyingZombie());   

    }*/

    IEnumerator dyingZombie()
    {
        //time = Time.time;
        zomb.Play("Z_FallingBack");


        yield return new WaitForSeconds(2.0f);

    }

} 

