using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    //private BoxCollider player;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 60f;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
        //player = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
       moveHorizontal = Input.GetAxisRaw("Horizontal"); 
       moveVertical = Input.GetAxisRaw("Vertical");

       /*if(Input.GetKeyDown("q")) 
       {
        player.size = new Vector3 (1, 0.5f, 1)
        player.center = new Vector3 (0, -0.25f, 0)
       }

       if(Input.GetKeyDown("e")) 
       {
        player.size = new Vector3 (1, 1, 1)
        player.center = new Vector3 (0, 0, 0)
       }*/
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed,0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f,moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
