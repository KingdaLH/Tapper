using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed; //Snelheid karakter.
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;

    private bool check1; //Checken bij welke tap de speler staat.
    private bool check2;
    private bool check3;

    public GameObject prefab; //Drank prefab.
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.AddComponent<BoxCollider2D>();
        speed = 2.5f;
        check1 = false;
        check2 = false;
        check3 = false;
        
    }

    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical"); 
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);}  


        if(Input.GetKeyDown("space") && check1)     
        {Instantiate(prefab, new Vector3(1.2f, -0.5f, 0.5f), Quaternion.identity);} //flesje op positie (positie moet de positie van het begin van bar1,bar2 of bar3 zijn)
        
        if(Input.GetKeyDown("space") && check2)     
        {Instantiate(prefab, new Vector3(0.85f, 0.25f, 0.5f), Quaternion.identity);}
        
        if(Input.GetKeyDown("space") && check3)     
        {Instantiate(prefab, new Vector3(0.6f, 0.9f, 0.5f), Quaternion.identity);}
        



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tap1") //checkt of player bij TapX staat
        {
            check1 = true;
        }
        if (collision.gameObject.tag == "Tap2")
        {
            check2 = true;
        }
        if (collision.gameObject.tag == "Tap3")
        {
            check3 = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        check1 = false; //uncheckt als de speler niet bij TapX staat
        check2 = false;
        check3 = false;
    }

    void MoveCharacter()
    {myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);}
}
