using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range =100f;

    public Camera fpsCam;

    public Animator gunAnim;

    public GameObject bulletImpact;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        void Shoot()
        {
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Instantiate(bulletImpact, hit.point, transform.rotation);

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }

                
            }
            gunAnim.SetTrigger("Shoot");
        }
        
    }
}
