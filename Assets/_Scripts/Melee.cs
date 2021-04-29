using UnityEngine;

public class Melee : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;

    public Camera fpsCam;

    public Animator gunAnim;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // fucntion uses racast to damage enemy
        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }

                
            }
            gunAnim.SetTrigger("Shoot");
        }

    }
}