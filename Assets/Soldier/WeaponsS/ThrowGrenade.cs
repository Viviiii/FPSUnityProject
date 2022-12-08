using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{

    //PlayerStats player;
    //AnimThrowGrenade animg;
    M4A1_Shoot gre_mun;
    [SerializeField]
    Rigidbody grenadeCasing;

    private float speedEject = 500f;
    private float fireR = 1f;
    private float nextFire = 0.0f;
    //PlayerController futuristic_soldier;

    [SerializeField]
    private Animator soldier_animator;
    AnimatorClipInfo[] currentClip;

    // Start is called before the first frame update
    void Start()
    {
        gre_mun = GameObject.Find("SK_AR_02").GetComponent<M4A1_Shoot>();
       //soldier_animator = GameObject.Find("Futuristic_soldier").GetComponent<Animator>();
       // futuristic_soldier = GameObject.Find("Futuristic_soldier").GetComponent<PlayerController>();

    }


   
    // Update is called once per frame
    void Update()
    {
        
        if (gre_mun.grenades > 0)
        {
            if (Input.GetKeyDown("g") && Time.time > nextFire)
            {
                nextFire = Time.time + fireR;
                
                //soldier_animator.SetTrigger("GrenadeTrig");
                Rigidbody gren;
                gren = Instantiate(grenadeCasing, transform.position, transform.rotation);
                gren.velocity = transform.TransformDirection(Vector3.forward * -speedEject);
                gre_mun.grenades -= 1;

            }
        }
        /*currentClip = soldier_animator.GetCurrentAnimatorClipInfo(0);
        
        if (soldier_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f && currentClip[0].clip.name == "Grenade")
        {
            print("En pleine anim");
            futuristic_soldier.speed = 0f;
    
        }
        else
        {
            print("Fin de l'anim");
            futuristic_soldier.speed = 40f;
        }*/
        
    }
}