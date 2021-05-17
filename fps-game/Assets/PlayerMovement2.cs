using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 28f;
    public float gravity = -30f;
    public Transform GroundCheck;
    public Transform TerrainCheck;
    public float GroundDistance = 0.4f;
    public float TerrainDistance = 0.4f;
    public LayerMask GroundMask;
    public LayerMask TerrainMask;
    public float JumpHeight = 5f;




    Vector3 velocity;


    bool isGrounded;
    bool isTerrain;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        //ground check for gravity



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = 0f;
        }
        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)    
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        // movement and gravity fall
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //Run
        if (Input.GetButton("sprint"))
        {
            speed = 35f;
        }
        else
        {
            speed = 28f;
        }
        
        
        isTerrain = Physics.CheckSphere(TerrainCheck.position, TerrainDistance, TerrainMask);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("3rd gun bunny"))
        {
            //Restart
            if (transform.position.y <= -3 || isTerrain)
            {    
                FindObjectOfType<GameManager>().Restart();
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("4th gun bunny"))
        {
            //Restart
           
            if (transform.position.y <= -170 || isTerrain)
            {
                FindObjectOfType<GameManager1>().Restart1();
            }
        }
    }



}