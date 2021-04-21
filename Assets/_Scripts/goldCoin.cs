using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldCoin : MonoBehaviour
{
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
            PlayerController.instance.gold += 1;
            PlayerController.instance.UpdateGoldUI();
            Destroy(gameObject);
        }
    }
}
