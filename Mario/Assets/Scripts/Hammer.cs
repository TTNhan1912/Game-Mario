using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speedUp;

    // Start is called before the first frame update
    void Start()
    {
        Rotation();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speedUp, 0);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {

        
    }
    public void SetScript(float value){
        speedUp = value;
    }
    public void Rotation(){
        if(speedUp > 0){
            transform.localScale = new Vector3(1F, 1F, 1F);
        }else{
            transform.localScale = new Vector3(-1F, 1F, 1F);
        }
    }
}
