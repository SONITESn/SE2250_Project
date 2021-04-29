using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] bool lockCursor = true;
    [SerializeField] float gravity = -13.0f;

    Vector3 velocity;
    bool isGrounded;
    public float jumpHeight = 3f;

    //CharacterController controller = null;

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;
    public float runSpeed = 7.5f;

    public Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitvity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;

    public Animator gunAnim;
    public Animator anim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool has_died;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Text healthText;
    public Text goldText;

    public int gold = 0;

    public int killPoints = 0;

    public int ePoints = 0;
    public Text points_text;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        //controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!has_died)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.z < 0)
            {
                velocity.z = 0f;
            }

            //player movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;

            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            velocity.z += gravity * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                theRB.velocity = (moveHorizontal + moveVertical) * runSpeed;
            }

            //(velocity * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.z = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //player view control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitvity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            if(moveInput != Vector2.zero)
            {
                anim.SetBool("IsMoving", true);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }

            
            
        }
    }

    // function when player takes damage from enemy
    public void TakeDamage(int damage_amount)
    {
        currentHealth -= damage_amount;

        if(currentHealth <= 0)
        {
            //deadScreen.SetActive(true);
            has_died = true;
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        healthText.text = currentHealth.ToString() + "%";

    }

    // function when player gets health
    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString() + "%";
    }

    //functions update player UI
    public void UpdateHealthUI()
    {
        healthText.text = currentHealth.ToString() + "%";
    }

    public void UpdateGoldUI()
    {
        goldText.text = gold.ToString();
    }

    public void UpdateEPointsUI()
    {
        points_text.text = ePoints.ToString();
    }
}
