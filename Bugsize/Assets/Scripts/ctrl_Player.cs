using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl_Player : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float jumpForce;
    public float jumpTime;

    public Transform feetPos;
    public LayerMask isStage;

    private float moveInput;
    private float jumpCont;
    private bool isGrounded;
    private bool isJumping;
    public bool verDerecha = true;
    private Rigidbody2D rigid2;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }/*________Start___________*/

    /*________Fixed_Update_____*/
    void FixedUpdate()
    {//Moverse
        moveInput = Input.GetAxisRaw("Horizontal");
        rigid2.velocity = new Vector2(moveInput * speed, rigid2.velocity.y);
    }/*________Fixed_Update_____*/
    /*________Update__________*/
    void Update()
    {    //Llama los valores del animator
        anim.SetFloat("Speed", Mathf.Abs(rigid2.velocity.x));
        anim.SetBool("Grounded", isGrounded);
       //Salto sensible
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isStage);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpCont = jumpTime;
            rigid2.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if(jumpCont > 0)
            {
                rigid2.velocity = Vector2.up * jumpForce;
                jumpCont -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
        //Mira Mouse

        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position
        if(delta.x >= 0 && !verDerecha)
        {
            transform.localScale = new Vector3(1, 1, 1);
            verDerecha = true;
        }else if(delta.x < 0 && verDerecha)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            verDerecha = false;
        }
    }/*________Update__________*/

}
