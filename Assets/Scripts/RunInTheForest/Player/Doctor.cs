using TMPro;
using UnityEngine;

public class Doctor : Player
{
    public float LaneDistance = 2.0f;
    public float MoveSpeed = 10.0f;
    public float JumpForce = 15.0f;
    private int CurrentLane = 1;
    [SerializeField] private ScoreManager scoreManager;

    private bool isCrouching = false;
    private bool isGrounded;

    private Vector3 velocity;

    private Animator doctorAnimation;
    
    private Rigidbody rigidBody;

    private float gravity = -9.81f;
    private int hp = 3;

    public UIManager UIManager; 
    public TextMeshProUGUI PointDeVie;

    public override void Start()
    {
        doctorAnimation = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, LayerMask.GetMask("Ground"));
        Controller();   
        Grounded();
        Death();
    }

    public void Death()
    {
        if (hp == 0)
        {
            UIManager.ShowGameLoseUI();
            UIManager.ShowGameOverUI();
            Debug.Log("You died");
        }
    }
    public override void Controller()
    {
        if (Input.GetKeyDown(KeyCode.A) && CurrentLane > 0)
        {
            Debug.Log("gauche");
            CurrentLane--;
            MoveToLane();
        }
        else if (Input.GetKeyDown(KeyCode.D) && CurrentLane < 2)
        {
            Debug.Log("Droite");
            CurrentLane++;
            MoveToLane();
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S) && !isCrouching)
        {
            StartCoroutine(Crouch());
        }
    }

    void Grounded()
    {
        if (isGrounded)
        {
            doctorAnimation.SetBool("Jump", false);
        }
    }
    void FixedUpdate()
    {
        if (!isGrounded)
        {
            rigidBody.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
    }
    public override void MoveToLane()
    {
        float targetX = (CurrentLane - 1) * LaneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    public override void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z);
        rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        isGrounded = false;
        Debug.Log("jump");
        doctorAnimation.SetBool("Jump", true);
    }

    public override System.Collections.IEnumerator Crouch()
    {
        isCrouching = true;
        doctorAnimation.SetBool("Crouch", true);
        yield return new WaitForSeconds(1.0f);
        isCrouching = false;
        doctorAnimation.SetBool("Crouch", false);
        Debug.Log("crouch");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            hp--;
            ModifierUIPointDeVie();
            Debug.Log("Trigger detected with obstacle!");
        }
        if (other.CompareTag("Win"))
        {
            scoreManager.AddScore(hp, 1);
            Debug.Log("work");
            UIManager.ShowGameWinUI();
            UIManager.ShowGameOverUI();
            Debug.Log("You Win!");
        }
    }
    public void ModifierUIPointDeVie()
    {
        PointDeVie.text = $"Point De Vie : {hp}";
    }
}
