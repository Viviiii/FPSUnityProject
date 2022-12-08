using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    

    public void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Bullet")
        {
            health -= 20;
        }
           
        if (health <= 0f)
        {
            GetComponent<Animator>().Play("Z_FallingBack");
            
            gameObject.GetComponent<IA>().enabled = false;
        }
    }

}   
