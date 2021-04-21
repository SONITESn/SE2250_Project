using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int healthAmmount = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(PlayerController.instance.currentHealth < 100)
            {
                if(PlayerController.instance.currentHealth + healthAmmount > 100)
                {
                    PlayerController.instance.currentHealth = 100;
                } else
                {
                    PlayerController.instance.currentHealth += healthAmmount;
                }
                
                PlayerController.instance.UpdateHealthUI();
                Destroy(gameObject);
            }
           
        }
    }
}
