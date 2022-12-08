using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using UnityEngine.AudioClip;

public class Pistol_Shoot : MonoBehaviour
{
    /// <summary>
    /// Ce pistolet est le Beretta 92
    /// </summary>
    
    Enemy target;
    SwapWeapon weap;
    [SerializeField]
    Rigidbody bulletCasing;

    [SerializeField]
    private int speedEject = 100;
    [SerializeField]
    private float fireR = 0.2f;
    private float reload_time = 2.0f;
    Transform pistol;
    [SerializeField]
    public int ammo = 30;
    public int magazine = 15;
    private float nextFire = 0.0f;
    public AudioSource tir;
    public AudioSource reload;
    public AudioSource click;

    void Start()
    {
        weap = GameObject.Find("Perso").GetComponent<SwapWeapon>();
    }


    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetButton("Fire1") && Time.time > nextFire && magazine > 0 && weap.equipped==2)
        {
            tir.Play();
            nextFire = Time.time + fireR;
            Rigidbody bullet;
            bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.forward * -speedEject);
            magazine = magazine - 1;

            print(magazine);

        }

        if (Input.GetButton("Fire1") && Time.time > nextFire && magazine == 0)
        {
            click.Play();
        }

         if (magazine == 0 && ammo > 0)
        {
            nextFire = Time.time + reload_time;
            reload.Play();
            ammo = ammo - (15 - magazine);
            magazine = 15;
        }

        if (Input.GetKeyDown("r") && magazine < 15)
        {
            nextFire = Time.time + reload_time;
            reload.Play();
            ammo = ammo - (15 - magazine);
            magazine = 15;
        }
    }

    public int getAmmo()
    {
        return ammo;
    }


}
