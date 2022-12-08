using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    M4A1_Shoot mun;


    public int M4A1Bonus = 15;
    public int PistolBonus = 5;
    public int GrenadeBonus = 2;

    [SerializeField]
    public AudioSource pickup;

    void Start()
    {
        mun = GameObject.Find("SK_AR_02").GetComponent<M4A1_Shoot>();                                                                        
    }

    void OnTriggerEnter(Collider col)
    {
        pickup.Play();
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            mun.ammo = mun.ammo + M4A1Bonus;
            mun.grenades = mun.grenades + GrenadeBonus;
        }

    }
}
