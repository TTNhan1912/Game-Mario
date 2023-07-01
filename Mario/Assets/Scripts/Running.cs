// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class Running : MonoBehaviour
// {
//     public Animator ani;
//     public float speed;
//     public new Rigidbody2D rigidbody2D;


//     // Start is called before the first frame update
//     void Start()
//     {
//         speed = 5f;
//         rigidbody2D = GetComponent<Rigidbody2D>();
//         isRight = true;
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKey(KeyCode.RightArrow)){
//             // xoay mat qua phai
//             if(isRight == false ){
//                 Vector2 scale = transform.localScale;
//                 scale.x *= scale.x < 0 ? -1 : 1 ;
//                 transform.localScale = scale;
//                 isRight = true;
//             }
              
                
            
//             rigidbody2D.velocity = new Vector2(speed,0);

//         }
//         if(Input.GetKey(KeyCode.LeftArrow)){
//             // xoay mat qua phai
//             if(isRight == true ){
//                 Vector2 scale = transform.localScale;
//                 scale.x *= scale.x > 0 ? -1 : 1 ;
//                 transform.localScale = scale;
//                 isRight = false;
//             }

//             rigidbody2D.velocity = new Vector2(-speed,0);

//         }
//         if(Input.GetKey(KeyCode.Space)){


//         }
        
//     }
// }
