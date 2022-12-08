using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int Health = 100;
    public int currentHealth;
    public Slider healthSlider;
   
    public bool damaged = false;
  
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = Health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        
            damaged = true;

            currentHealth -= amount;

            healthSlider.value = currentHealth;
        
        
    }
}
