using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
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
            if(PlayerController.instance.killPoints == 5) //checks if player finishes objecives
            {
                SceneManager.LoadScene("End_Game"); //player spawns at endgame scene
            }
      
        }
    }

}
