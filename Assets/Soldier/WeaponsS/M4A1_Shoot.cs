using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UIElements;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Runtime.InteropServices.WindowsRuntime;
//using UnityEngine.AudioClip;

public class M4A1_Shoot : MonoBehaviour
{
    //private Camera cam;
   
    Enemy target;
    GameObject M4A1;
    //PlayerController futuristic_soldier;
    [SerializeField]
    IAHealth zombieHP;
    [SerializeField]
    Rigidbody bulletCasing;
    [SerializeField]
    Camera cam;
    public Rigidbody bullet;
    GameObject crosshair;

    [SerializeField]
    private int speedEject;
    [SerializeField]
    private float fireR = 0.8f;
    private float reload_time = 2.5f;
    //PlayerHealth h;

    [SerializeField]
    public int ammo = 90;
    public int magazine = 30;
    public int grenades = 2;
    private float nextFire = 0.0f;
    private Ray ray;
    private RaycastHit hit;
    private bool fullAuto = false;
    //public AudioSource tir;
    public AudioSource reloadS;
    public AudioSource click;


    AnimatorClipInfo[] currentClip;
    [SerializeField]
    private Animator soldier_animator;

    void Start()
    {
        //futuristic_soldier = GameObject.Find("Futuristic_soldier").GetComponent<PlayerController>();
        zombieHP = GameObject.Find("Zombie").GetComponent<IAHealth>();
        //soldier_animator = GameObject.Find("Futuristic_soldier").GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //Algo à ajouter : if bullet touches zombie, bullet disappear, if bullet doesnt touch anything, wait 1 sec and destroy
        //Add more time to reload
        if (Input.GetButton("Fire1") && Time.time > nextFire && magazine > 0)
        {
            Vector3 zMov = transform.forward * 1;
            Vector3 velocity = zMov.normalized * speedEject;

            //tir.Play();
            //  soldier_animator.SetBool("Reload", false);
            //soldier_animator.SetBool("Shooting", true);
            nextFire = Time.time + fireR;

            Quaternion rot = new Quaternion(-0.3f, 0f, 1f, 0f);
            Vector3 trajectory = new Vector3(-0.3f, 0f, 1f);
            Vector3 centre = new Vector3(0.5f, 0.5f, 0);
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
                    //bullet.velocity = transform.forward * speedEject;
                    //bullet.transform.position = Input.mousePosition;
                    // bullet.transform.Rotate(Vector3.forward * speedEject * Time.deltaTime);
                    //bullet.transform.rotation = Quaternion.LookRotation(hit.point - transform.position);
                    bullet.AddForce((hit.point - transform.position).normalized * speedEject, ForceMode.Impulse);
                    //bullet.transform.LookAt(centre);
                    if (hit.transform.tag == "Enemy")
                    {
                        
                        /*for (int i = 0; i < zombieHP.zombiesGO.Count; i++)
                        {
                            if (hit.transform.position == zombieHP.zombiesGO[i].transform.position)
                            {
                                Debug.Log("Numero :" + i);
                                //zombieHP.zombieArray[i].setHP(zombieHP.zombieArray[i].setHP() - 25);
                            }
                        }*/
                    }
                }
               


            }
            magazine = magazine - 1;
        }

        /*IEnumerator shoot()
        {
            
            yield return new WaitForSeconds(.01f);
            //soldier_animator.SetBool("Shooting", false);
        }*/
        if (magazine == 0 && ammo > 0)
        {
            reload();
        }
        if (Input.GetKeyDown("r") && magazine < 30)
        {
            reload();

        }

        void reload()
        {
            nextFire = Time.time + reload_time;
            ammo = ammo - (30 - magazine);
            magazine = 30;
            //reloadS.Play();

            //soldier_animator.SetTrigger("Reload");
        }
        /*if (Input.GetButton("Fire1") && Time.time > nextFire && magazine > 0 &&  weap.equipped== 1)
        {

            tir.Play();
            nextFire = Time.time + fireR;
            Rigidbody bullet;
            bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
            bullet.velocity = transform.TransformDirection(Vector3.forward * speedEject);
            magazine = magazine - 1;

            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    //Destroy(bullet);
                    //hit.rigidbody.AddForceAtPosition(transform.TransformDirection(-Vector3.forward) * 1000, hit.normal);

                }
                else if(hit.transform.gameObject.tag == "Mur")
                {
                    GameObject impact = Instantiate(bulletHole, hit.point, Quaternion.FromRotation(Vector3.forward, hit.normal)) as GameObject;
                }
            }
            yield return new WaitForSeconds(.5f);
            Destroy(bullet);

        }*/
        //soldier_animator.SetBool("Reload", false);

        //bullet = Instantiate(bulletCasing, transform.position, rot);
        /*if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo))
        {
            bullet.transform.LookAt(hitInfo.point);
            print(hitInfo.point);
        }
        else
        {
            bullet.MovePosition(bullet.transform.position + velocity * Time.fixedDeltaTime);
            //bullet.transform.LookAt(bullet.transform.forward);
            print("Nothing in sight !");
        }*/
        /*ray.origin = transform.position;
        ray.direction = Vector3.left;
        bool wRay;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            Debug.Log("+10 pts");
            bullet.AddForce(bullet.transform.forward * speedEject, ForceMode.VelocityChange);

        }
        else
        {
            Debug.Log("Nothing in sight");
        }*/






        //

        /*Debug.DrawLine(ray.origin, hit.point);
        crosshair.transform.position = hit.point;
        bullet.transform.LookAt(hit.point);*/


        /* Vector3 centre = new Vector3(Screen.width / 2, Screen.height / 2, 0);
         ray = cam.ScreenPointToRay(centre);
         if (Physics.Raycast(ray, hit, 10000))
         {
             Debug.DrawLine(ray.origin, hit.point);
             crosshair.transform.position = hit.point;
             bullet.transform.LookAt(hit.point);
         }*/
        //bullet.velocity = transform.TransformDirection(trajectory * speedEject);





        /*if (Physics.R   aycast(ray, out hit, Camera.main.farClipPlane))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                //Destroy(bullet);
                //hit.rigidbody.AddForceAtPosition(transform.TransformDirection(-Vector3.forward) * 1000, hit.normal);

            }
            else if(hit.transform.gameObject.tag == "Mur")
            {
                GameObject impact = Instantiate(bulletHole, hit.point, Quaternion.FromRotation(Vector3.forward, hit.normal)) as GameObject;
            }
        }*/

        //Destroy(bullet.gameObject, 1f);


        //soldier_animator.SetBool("Shooting", false);

        /*ANIMATION TO SEE LATER
        if (Input.GetButton("Fire1") && Time.time > nextFire && magazine == 0)
        {
            //click.Play();
        }

        currentClip = soldier_animator.GetCurrentAnimatorClipInfo(0);
        
        if (soldier_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f && (
            currentClip[0].clip.name == "Reloading"||
            currentClip[0].clip.name == "Grenade"))
        {

            futuristic_soldier.speed = 0f;

        }
        else

        {
            futuristic_soldier.speed = 40f;
        }
        */
        if (Input.GetKeyDown("v"))
        {
            fullAuto = !fullAuto;
        }
        /*if (fullAuto == true)
        {
            fireR = 0.1f;
        }
        else
        { fireR = 0.5f; }*/
    }

    public int getAmmo()
    {
        return ammo;
    }
    
     
}
