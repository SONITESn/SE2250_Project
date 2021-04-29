using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bullet_speed = 3f;

    public Rigidbody2D theRB;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bullet_speed;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bullet_speed; //follow player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount); //damage player
            Destroy(gameObject);
        }
    }
}
