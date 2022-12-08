using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WeaponController : MonoBehaviour
{

    IA zombieIA;
    //GameObject zombieRigidbody;
    [SerializeField]
    public float speed = 10f;
    private CharacterController characterController;
    private bool groundedPlayer;

    [SerializeField]
    private Camera cam;
    private float sensitivity = 2f;
    private float gravity = -15f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerVelocity;
    public float jumpHeight = 10f;
    public float gravityMultiplier = 1f;
    public float lookXLimit = 20.0f;
    private float rotationX = 0f;
    public float zMov;
    public float xMov;
    //private Vector3 spawnPos;
    //public int nbrZombies;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.Find("SK_AR_02").GetComponent<CharacterController>();
        //zombieS = GameObject.Find("Zombie").GetComponent<IA>();
        //zombieRigidbody = GameObject.Find("Zombie");
        Cursor.lockState = CursorLockMode.Locked;
        //nbrZombies = 5;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ///PLAYER AND CAMERA ROTATION
        groundedPlayer = characterController.isGrounded;
        rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);

        //Jumping
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
      
        }
        if(!groundedPlayer)
        {
            playerVelocity.y += gravity * 0.1f;
        }
        

        ///PLAYER MOVEMENT
        /*if(transform.rotation.y> 0f)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        if(transform.rotation.y <0f)
        {
            moveDirection = new Vector3(- Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }*/
         moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * Time.deltaTime * speed);

        if (moveDirection == Vector3.zero)
        {
            characterController.Move(Vector3.zero);
        }
       
        if (Input.GetButton("Jump") /*&& groundedPlayer*/)
        {

            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity); ;
        }
        characterController.Move(moveDirection * Time.deltaTime * speed);
        playerVelocity.y += gravity * Time.deltaTime;
        //moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

    }

    //Changer de fichier !!
    /*void respawn()
    {
        spawnPos = new Vector3(Random.Range(-185.0f, 296.0f), transform.position.y, Random.Range(-35.0f, 442.0f));
        zombieS.zombiesGO.Add((GameObject)Instantiate(zombieRigidbody, spawnPos, transform.rotation));
        zombieS.gameObject.AddComponent<IA>();
        Instantiate(gameObject, transform.position + new Vector3(4.0F, 0.0F, -1), transform.rotation);

        zombieS.respawnRate = Time.time + zombieS.respawnRate;
        nbrZombies++;
    }*/
}
