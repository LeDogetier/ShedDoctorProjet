using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speed = 5f;
    private float gravity = -9.81f;
    private float jumpHeight = 2f;

    [SerializeField]
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    [SerializeField]
    private Animator animator;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        bool isWalking = moveX != 0f || moveZ != 0f;

        animator.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }


}
