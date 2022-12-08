using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int BonusHealth = 50;
     Rigidbody rb;

    public Vector3 position;
    PlayerStats joueur;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>();
        rb = GameObject.Find("Heart").GetComponent<Rigidbody>();
        position = rb.position;
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag == "Player")
        {
            print("+20 hp !");
            GiveHealth(BonusHealth);
            Destroy(gameObject);

            //GetComponent<Animator>().Play("HeartDestroy");
        }

        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            print("+20 hp !");
            GiveHealth(BonusHealth);
            Destroy(gameObject);

            //GetComponent<Animator>().Play("HeartDestroy");
        }

        else if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
    public void GiveHealth(int amount)
    {
        joueur.currentHealth = amount;
    }
}
