using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhim : MonoBehaviour
{
    bool gioi_han_trai;
    bool gioi_han_phai;
    
    // // kill quái
    // private Vector2 originalPosition;
    // public GameObject newBlock;
    // public float speed,height;

    // Start is called before the first frame update
    void Start()
    {
        // // kill quái 
        // originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gioi_han_trai){ 
            transform.Translate(Time.deltaTime, 0 ,0 ); // chạy qua phải
            transform.localScale = new Vector3(-1F,1F,1F);
            if (gioi_han_phai){
                transform.Translate(-Time.deltaTime, 0, 0 );
                transform.localScale = new Vector3(1F,1F,1F);
            }
        }else{
            transform.Translate(-Time.deltaTime ,0 ,0); // chạy qua trái
            transform.localScale = new Vector3(1F,1F,1F);
        }

        // if (gioi_han_phai){
        //     transform.Translate(-Time.deltaTime, 0, 0 );
        //     transform.localScale = new Vector3(1F,1F,1F);
        // }else{
        //     transform.Translate(Time.deltaTime ,0 ,0);
        //     transform.localScale = new Vector3(-1F,1F,1F);
        // }

    }
        
        private void OnCollisionEnter2D(Collision2D collision){ 
            if(collision.gameObject.tag == "gioi_han_trai"){
            gioi_han_trai = true;
            }
            if(collision.gameObject.tag == "gioi_han_phai"){
            gioi_han_phai = true;
            }
    }
        
    //     private void OnTriggerEnter2D(Collider2D collisionn) {
    //         if (collisionn.gameObject.tag == "ben_tren"){
    //              // Nảy lên rồi rớt xuống
    //             StartCoroutine(GoUpAndDown());
    //         }

            
    //     }
    //     // kill quái
    //     IEnumerator GoUpAndDown(){
    //     while (true)
    //     {
    //         transform.position = new Vector2 (
    //             transform.position.x,
    //             transform.position.y + speed * Time.deltaTime);
    //         if (transform.position.y > originalPosition.y + height) break;
    //             yield return null;
    //     }

    //     while (true){
    //         transform.position = new Vector2(
    //             transform.position.x,
    //             transform.position.y - speed * Time.deltaTime);
    //         // if (transform.position.y < originalPosition.y){ // Chặn lại không cho rớt thêm
    //         //     transform.position = originalPosition;
    //         //     break;
    //         // }
    //         yield return null;

    //     }

    // }
}
