using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    public Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitvity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;

    public Animator gunAnim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool has_died;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!has_died)
        {
            //player movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;

            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            //player view control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitvity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //shooting
            //if (Input.GetMouseButtonDown(0))
            //{
            //    if (currentAmmo > 0)
            //    {
            //        Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            //        RaycastHit hit;
            //        if (Physics.Raycast(ray, out hit))
            //        {
            //            Debug.Log("I'm looking at " + hit.transform.name);
            //            Instantiate(bulletImpact, hit.point, transform.rotation);
            //
            //            if (hit.transform.tag == "Enemy")
            //            {
            //                hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
            //            }
            //        }
            //        else
            //        {
            //            Debug.Log("I'm looking at nothing");
            //       }
            //        currentAmmo--;
            //        gunAnim.SetTrigger("Shoot");
            //    }
            //}
        }
    }

    public void TakeDamage(int damage_amount)
    {
        currentHealth -= damage_amount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            has_died = true;
        }

    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
