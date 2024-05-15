using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementXY : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    // Atrito ch�o
    public float groundDrag;

    // Configura��es do Pulo
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    // Encontrar o Ch�o
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    void Start()
    {
        // Pega os componentes e ativa o pulo
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    void MyImput()
    {
        // Pega os inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // A a��o de pular quando aperta o jumpKey
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    
    void Update()
    {
        // Verifica o ch�o fazendo um tra�o do personagem para baixo, ativa true quando passa a layer
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 
        
        MyImput();
        SpeedControl();

        // Atrito quando est� no ch�o
        if (grounded)
            rb.drag = groundDrag;
        // Tira o atrito quando est� no ar
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Faz a movimenta��o ser em todas as dire��es
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Velocidade no ch�o
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // Velocidade no ar durante o pulo
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

     
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limite de velocidade
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Limite do pulo
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
