using UnityEngine;

public class MiniGun : MonoBehaviour
{
    public static MiniGun instance;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;

    public Animator gunAnim;

    public GameObject bulletImpact;

    private float nextTimeToFire= 0f;

    public int currentAmmo = 100;

    // Update is called once per frame

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
       
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            
            if (currentAmmo > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                currentAmmo--;
            }
        }

        void Shoot()
        {
            
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
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
