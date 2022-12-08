using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public int health = 100;
    public int currentHealth;
    public int score = 0;
    public Slider healthSlider;

    public bool damaged = false;
    //public int grenade = 2;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {

        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

    }
}
