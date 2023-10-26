using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public float playerSpeed = 2f;
    //All old variables for arm bending mechanic
    /*
    public GameObject leftHand;
    public UnityEngine.Vector3 leftRotatePoint;
    public GameObject rightHand;
    public UnityEngine.Vector3 rightRotatePoint;
    */
    public Transform playerFacingVector;
    public TilemapCollider2D pegCollision;
    public Color pegShade;
    public Tilemap pegTilemap;
    public LayerMask whatIsKillBlock;


    private Rigidbody2D rb;
    //private bool isMoving = false;
    //Old variables for arm bending mechanic
    /*
    private bool leftHandActive = false;
    private bool rightHandActive = false;
    */
    private UnityEngine.Vector2 playerDirection;
    private Color ogPegColour;
    public bool isDead = false;

    void Awake() {
        isDead = false;
    }    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Setting the variables of the shader colour
        //Help: https://discussions.unity.com/t/making-sprites-darker-shadowed/122773
        pegShade.r = 0.6f;
        pegShade.g = 0.6f;
        pegShade.b = 0.6f;
        pegShade.a = pegTilemap.color.a;
        pegShade.b = pegTilemap.color.b;
        //This one is so i can set it back to the original peg colour
        ogPegColour = pegTilemap.color;
    }

    // Update is called once per frame
    void Update()
    {
        //Doc to help me for moving forward: https://discussions.unity.com/t/transform-forward-in-2d/182904
        //isMoving = true;

        //Old WASD Movement
        /*
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new UnityEngine.Vector2(directionX, directionY).normalized;
        */

        //playerFacingVector is right in front of the player, the x and y are minused from the player's x and y
        playerDirection = new UnityEngine.Vector2(playerFacingVector.transform.position.x - rb.transform.position.x, playerFacingVector.transform.position.y - rb.transform.position.y).normalized;

        if (Input.GetMouseButtonDown(0)) {
            
            if (pegCollision.enabled) {
                //Darken pegs
                pegTilemap.color = pegShade;
            }

            else {
                //Return pegs to original colour
                pegTilemap.color = ogPegColour;
            }
            
            //Flip whether pegCollision is on
            pegCollision.enabled = !pegCollision.enabled;

            AudioManager.instance.PlayPegClip();

            //Old arm bending system, changed the game mechanic to be pegs changing instead
            /*
            if (leftHandActive) {
                leftHand.transform.Rotate(new UnityEngine.Vector3(0, 0, 90), 90);
                leftHandActive = !leftHandActive;
            }

            else {
                leftHandActive = !leftHandActive;
                leftHand.transform.Rotate(new UnityEngine.Vector3(0, 0, 90), -90);
            }
            */
        }
    }

    void FixedUpdate()
    {
        //Multiplying playerSpeed by the player's front direction
        rb.velocity = new UnityEngine.Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        //Check if player is touching kill block
        if (other.collider.tag == "KillBlock") {
            isDead = true;
            GameManager.instance.RestartGame();
        }
    }
}
