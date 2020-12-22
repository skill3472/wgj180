using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float speed;
    public float jumpForce;
    public Rigidbody2D playerRb;
    [SerializeField] private float horizontalAxis;
    public bool isGrounded;
    [SerializeField] private Transform groundDetector;
    public bool breathingToExist;
    [SerializeField]private int currentDogIndex;

    [SerializeField]private float timeLeftToBreathe;

    // Start is called before the first frame update
    void Start()
    {
        alphaWolf();
        timeLeftToBreathe = 10;
    }

    // Update is called once per frame
    void Update()
    {
        DebugStuff(); //DO USUNIECIA
        if(breathingToExist) BreatheTest(10);
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.15f, groundLayer);
        horizontalAxis = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalAxis * speed, playerRb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void changeDogLevel(int dogLevel)
    {
        switch (dogLevel)
        {
            case 0: alphaWolf(); break;
            case 1: wolf(); break;
            case 2: mastif(); break;
            case 3: kundel(); break;
            case 4: owczarek(); break;
            case 5: mops(); break;
        }
    }

    void alphaWolf()
    {
        Debug.Log("PIES TO TERAZ WILK ALFA");
        speed = 12;
        jumpForce = 500;
        breathingToExist = false;
        currentDogIndex = 0;
    }

    void wolf()
    {
        Debug.Log("PIES TO TERAZ WILK");
        speed = 10;
        jumpForce = 450;
        breathingToExist = false;
        currentDogIndex = 1;
    }

    void mastif()
    {
        Debug.Log("PIES TO TERAZ MASTIF");
        speed = 8;
        jumpForce = 400;
        breathingToExist = false;
        currentDogIndex = 2;
    }

    void kundel()
    {
        Debug.Log("PIES TO TERAZ KUNDEL");
        speed = 6;
        jumpForce = 300;
        breathingToExist = false;
        currentDogIndex = 3;
    }

    void owczarek()
    {
        Debug.Log("PIES TO TERAZ OWCZAREK");
        speed = 4;
        jumpForce = 250;
        breathingToExist = false;
        currentDogIndex = 4;
    }

    void mops()
    {
        Debug.Log("PIES TO TERAZ MOPS");
        speed = 2;
        jumpForce = 100;
        breathingToExist = true;
        currentDogIndex = 5;
    }

    public void Death()
    {
        //PLAY DEATH SOUND HERE
        //MAYBE PARTICLES HERE?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("You died.");
    }

    void BreatheTest(float timeToBreathe)
    {
        timeLeftToBreathe -= Time.deltaTime;
        if(Input.GetButtonDown("Breathe"))
        {
            timeLeftToBreathe = timeToBreathe;
        }
        if(timeLeftToBreathe < 5)
        {
            Debug.Log("5 seconds left!");
        }
        if(timeLeftToBreathe < 0)
        {
            Death();
        }
    }




    void DebugStuff()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) Death();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeDogLevel(currentDogIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeDogLevel(currentDogIndex - 1);
        }
    }
}
