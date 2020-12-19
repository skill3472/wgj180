using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float speed;
    public float jumpForce;
    public Rigidbody2D playerRb;
    [SerializeField] private float horizontalAxis;
    public bool isGrounded;
    [SerializeField] private Transform groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.15f, groundLayer);
        horizontalAxis = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalAxis * speed, playerRb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
