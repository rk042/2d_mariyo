using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour {

    public float speed = 0;
    public float jumpforc = 0;
    private float moveinput = 0;
    private Rigidbody2D rd;
    private bool facinright = true;
    private bool isgrounded;
    public Transform grounchack;
    public float chacheraigs;
    public LayerMask whatisground;

    public Animator animator;
    private int exrajump;
    public int exrajumpvalue;


  	void Start () {
        exrajumpvalue = exrajump;
        rd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        isgrounded = Physics2D.OverlapCircle(grounchack.position, chacheraigs, whatisground);
        moveinput = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(moveinput * speed, rd.velocity.y);
        if (facinright == false && moveinput > 0)
            flip();
        else if (facinright == true && moveinput < 0)
            flip();
	}
    void Update()
    {
        animator.SetFloat("speed",Mathf.Abs(moveinput));
        if(isgrounded==true)
        {
            exrajump =exrajumpvalue;
        }
        if (Input.GetKey(KeyCode.UpArrow) && exrajump > 0)
        {
            rd.velocity = Vector2.up * jumpforc;
            exrajump--;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && exrajump == 0 && isgrounded==true)
        {
            rd.velocity = Vector2.up * jumpforc;
        }


    }
    void flip()
    {
        facinright = !facinright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
