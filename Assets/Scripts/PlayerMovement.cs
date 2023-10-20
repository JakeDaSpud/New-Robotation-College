using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public float playerSpeed = 2f;
    public GameObject leftHand;
    public UnityEngine.Vector3 leftRotatePoint;
    public GameObject rightHand;
    public UnityEngine.Vector3 rightRotatePoint;
    public GameObject playerFacingVector;



    private Rigidbody2D rb;
    private bool isMoving = false;
    private bool leftHandActive = false;
    private bool rightHandActive = false;
    private UnityEngine.Vector2 playerDirection;

    void Awake() {
    }    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Doc to help me for moving forward: https://discussions.unity.com/t/transform-forward-in-2d/182904
        isMoving = true;

        //Old WASD Movement
        /*
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new UnityEngine.Vector2(directionX, directionY).normalized;
        */

        //playerFacingVector is right in front of the player, the x and y are minused from the player's x and y
        playerDirection = new UnityEngine.Vector2(playerFacingVector.transform.position.x - rb.transform.position.x, playerFacingVector.transform.position.y - rb.transform.position.y).normalized;

        if (Input.GetMouseButtonDown(0)) {
            if (leftHandActive) {
                leftHand.transform.Rotate(new UnityEngine.Vector3(0, 0, 90), 90);
                leftHandActive = !leftHandActive;
            }

            else {
                leftHandActive = !leftHandActive;
                leftHand.transform.Rotate(new UnityEngine.Vector3(0, 0, 90), -90);
            }
        }
    }

    void FixedUpdate()
    {
        //Multiplying playerSpeed by the player's front direction
        rb.velocity = new UnityEngine.Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}
