using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    public float gravityMultiplier;

    public bool caught;
    public bool onFloor;

    Rigidbody2D myBody;
    SpriteRenderer myRenderer;
   // public Animator animator;
    public Sprite walkSprite;
    public Sprite jumpSprite;
    public Sprite caughtSprite;

    public static bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor && myBody.velocity.y > 0.5)
        {
            //Debug.Log("onfloor-false");
            onFloor = false;
        }
        CheckKeys();
        JumpPhysics();
    }

    void CheckKeys()
    {
        if (caught == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                faceRight = true;
                myRenderer.flipX = false;
                if (onFloor)
                {

                }
                HandleLRMovement(speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                faceRight = false;
                myRenderer.flipX = true;
                HandleLRMovement(-speed);
            }

            if (Input.GetKey(KeyCode.W) && onFloor)
            {
                myRenderer.sprite = jumpSprite;
                myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
            }
            else if (!Input.GetKey(KeyCode.W) && !onFloor)
            {
                myBody.velocity += Vector2.up * Physics2D.gravity * (jumpHeight - 1f) * Time.deltaTime;
            }
        }
       
    }

    void JumpPhysics()
    {
        if(myBody.velocity.y < 0.1)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    void HandleLRMovement(float dir)
    {
        myBody.velocity = new Vector3(dir, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            myRenderer.sprite = walkSprite;
            onFloor = true;
            myBody.velocity = new Vector3(myBody.velocity.x, 0);
        }
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "catch")
        {
            caught = true;
            myRenderer.sprite = caughtSprite;
        }
    }

}
