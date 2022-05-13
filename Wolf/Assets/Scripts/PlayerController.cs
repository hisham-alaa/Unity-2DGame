using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jump = 10f;

    bool isJump ;
    SpriteRenderer mySprite;
    Rigidbody2D myRB;
    Animator myAnimator;


    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        isJump = false;
    }

    private void Update()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.UpArrow)) && isJump == false)
        {
            myRB.velocity = new Vector2(0, jump);
            myAnimator.SetBool("Jump",true);
            isJump = true;
        }
        else
            myAnimator.SetBool("Jump", false);

        if (Mathf.Abs(myRB.velocity.y) < 0.001f)
            isJump = false;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            myAnimator.SetBool("Crouch", true);
        else
            myAnimator.SetBool("Crouch", false);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            myAnimator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            myAnimator.SetBool("Run", true);
        }
        else
            myAnimator.SetBool("Run", false);

        myRB.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), myRB.velocity.y);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check
        //if enemy then health-1 collision.comparetag
        if (collision.CompareTag("Enemy"))
        {

        }
        else if (collision.name == "Stairs")
        {

        }
        else if (collision.name == "Food")
        {
            
        }

        //if food score increase
        //if heart then health+1
        //if laider then climb true
        //if door go to the next level 

    }

}
