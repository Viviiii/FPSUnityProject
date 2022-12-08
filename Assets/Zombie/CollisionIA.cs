using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CollisionIA : IA
{
    WeaponController weapctrl;
    PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        weapctrl = GameObject.Find("SK_AR_02").GetComponent<WeaponController>();
        player = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>();
    }
       
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
    /*private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemy")
             Debug.Log("Stop hitting me please, it hurts");
     }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for(int i=0;i< nbrZombies; i++)
            {
                
                zombieArray[i].isAttacking = true;
                if (Time.time > zombieArray[i].attackRate)
                {
                    zombieArray[i].setMoveSpeed(0f);
                    zomb.Play("Z_Attack");
                    player.TakeDamage(25);

                }
            }
            
        
                
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < nbrZombies; i++)
        {
            zombieArray[i].isAttacking = false ;

        }
    }
}
