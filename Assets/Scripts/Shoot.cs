using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using UnityEngine.AudioClip;

public class Shoot : MonoBehaviour
{
    private Camera cam;
    Enemy target;
    SwapWeapon weap;
    [SerializeField]
    Rigidbody bulletCasing;
    
    [SerializeField]
    private int speedEject = 100;
    [SerializeField]
    private float fireR = 0.5f;
    PlayerHealth h;
    
    [SerializeField]
    public int ammo = 12;
    public int magazine = 12;
    private float nextFire = 0.0f;
    private Ray ray;
    private RaycastHit hit;
    private bool fullAuto = false;
    public AudioSource tir;
    public AudioSource reload;
    
    void Start()
    {
  

    }

    
    // Update is called once per frame
    void Update() 
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire && ammo > 0)
        {
            tir.Play();
            nextFire = Time.time + fireR;
            Rigidbody bullet;
            bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.forward * -speedEject);
            ammo = ammo - 1;
            //h.TakeDamage(20);
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    //Destroy(bullet);
                    //hit.rigidbody.AddForceAtPosition(transform.TransformDirection(-Vector3.forward) * 1000, hit.normal);

                }
                /*else if(hit.transform.gameObject.tag == "Mur")
                {
                    GameObject impact = Instantiate(bulletHole, hit.point, Quaternion.FromRotation(Vector3.forward, hit.normal)) as GameObject;
                }*/
            }
            
        }
       
        if (Input.GetKeyDown("r") && ammo < 12)
        {
            reload.Play();
            ammo = 12;
        }
        if (Input.GetKeyDown("v"))
        {
            fullAuto = !fullAuto;
        }
        if(fullAuto==true)
        {
            fireR = 0.1f;
        }
        else 
        {fireR = 0.5f;}
    }

    public int getAmmo()
    {
        return ammo;
    }
    /*void Shooting()
     {
         //muzzleFlash.Play();
          RaycastHit hit;
          if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, gun.range))
          {

              Enemy target = hit.transform.GetComponent<Enemy>();
              if (target != null)
              {
                  target.TakeDamage(gun.damage);
              }
          }
         nextFire = Time.time + fireR;
          Rigidbody bullet;
          bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
          bullet.velocity = transform.TransformDirection(Vector3.left * speedEject);
         if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
         {
             if(hit.transform.gameObject.tag == "Ennemy")
             {
                 hit.rigidbody.AddForceAtPosition(transform.TransformDirection(-Vector3.forward) * 1000, hit.normal);
             }
             /*else if(hit.transform.gameObject.tag == "Mur")
             {
                 GameObject impact = Instantiate(bulletHole, hit.point, Quaternion.FromRotation(Vector3.forward, hit.normal)) as GameObject;
             }
         }


     }*/
}
