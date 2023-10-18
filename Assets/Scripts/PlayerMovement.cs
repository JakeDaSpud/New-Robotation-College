using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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



    private Rigidbody2D rb;
    private UnityEngine.Vector2 playerDirection;
    private bool isMoving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = true;
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new UnityEngine.Vector2(directionX, directionY).normalized;

        if (Input.GetMouseButtonDown(0)) {
            leftHand.transform.RotateAround(leftRotatePoint, new UnityEngine.Vector3(1, 0, 0), 90);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new UnityEngine.Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}
