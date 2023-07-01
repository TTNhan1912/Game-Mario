using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    private int life;
    public Text lifeText;
    private Vector2 originalPosition;



    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        lifeText.text = life + "";

        originalPosition = transform.localPosition;
        Debug.Log("Lay vi tri ban dau!!!!!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        //Bắt sựu kiện 2 box collider va chạm nhau
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rua")){
            //Kiểm tra chạm trên , dưới, phải, trái
            
            /*direction.x == 1: Cham ben phai
            direction.x == -1: Cham ben trai
            direction.y == -1: Cham ben duoi
            direction.y == 1: Cham ben tren*/
            
            Vector2 direction = collision.GetContact(0).normal;
            float directionX = direction.x;
            float directionY = direction.y;
            if (directionX > 0)
            {
                //mario chết
                Destroy(gameObject);
                LifeRespawn();
            }
            else if (directionX < 0)
            {
                //mario chết
                Destroy(gameObject);
                LifeRespawn();
            }
            // else if(directionY > 0)
            // {
            //     //Giết quái
            //     //Destroy(collision.gameObject);
            // }
            else
            {
                //mario chết
                Destroy(gameObject);
                LifeRespawn();
            }
        }
        if (collision.gameObject.CompareTag("BossFireBall")){
                Destroy(gameObject);
                LifeRespawn();
        }
        if(collision.gameObject.tag == "player"){
            Destroy(GameObject.Find("char"));
        }
    


    }
        private void LifeRespawn(){
        if(life >= 1){
            life--;
            lifeText.text = life + "";
            transform.localPosition = originalPosition;
            
        }else{
            // Game Over
            Debug.Log("Game Over");
        }
        
    }
}
