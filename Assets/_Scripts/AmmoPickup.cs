using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function if player comes in contact with pickup
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //player gets item and update UI
            MiniGun.instance.currentAmmo += ammoAmount;
            MiniGun.instance.UpdateAmmoUI();

            Destroy(gameObject);
        }
    }
}
