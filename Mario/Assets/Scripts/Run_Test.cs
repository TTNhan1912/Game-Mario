using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Test : MonoBehaviour
{

    public Animator ani;
    public bool nen_dat ;
    public Rigidbody2D rigidbody2d;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            ani.SetBool("Run",true);
            ani.Play("run");

            transform.Translate(-Time.deltaTime * 5, 0, 0);

            transform.localScale = new Vector3(1F, 1F, 1F);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            ani.SetBool("Run",true);
            ani.Play("run");

            transform.Translate(Time.deltaTime * 5, 0, 0);
        }
        if(Input.GetKey(KeyCode.Space)){
            if(nen_dat == true ){
                ani.SetBool("isJump",false);
                ani.Play("nhay");
                rigidbody2d.AddForce(new Vector2(0,600));
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "nen_dat"){
            nen_dat = true;
            }
            
        }
}
