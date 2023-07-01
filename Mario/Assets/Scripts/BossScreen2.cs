using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossScreen2 : MonoBehaviour, IHpInterface
{
    public float left, right;
    public float speed;
    public bool isRight;

    public GameObject bossFireBall;
    private float timeSpawn; // thời gian bắn ra 1 viên đạn
    private float time; // thời gian đếm

    public int currentHp; // thanh máu

    // Start is called before the first frame update
    void Start()
    {
        timeSpawn = 1;
        time = timeSpawn;
    }

    // Update is called once per frame
    void Update(){
      
        float positionX = transform.position.x;
        if(positionX < left)
        {
            //Quay qua phai
            isRight = true;
        }
        else if(positionX > right) 
        {
            //Quay qua trai
            isRight = false;
        }
        Vector3 vector3;
        if (isRight)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;

            vector3 = new Vector3(1, 0, 0);
        }
        else
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;

            vector3 = new Vector3(-1, 0, 0);
        }
        transform.Translate(vector3 * speed * Time.deltaTime);

        time -= Time.deltaTime;
        if(time <= 0){
            time = timeSpawn;
            GameObject fb = Instantiate(bossFireBall);
            fb.transform.position = new Vector2(
                transform.position.x + (isRight ? 1f : -1f),
                transform.position.y
            );
        fb.GetComponent<BossFireBall>().SetScript(
            isRight ? 20 : -20
        );
        }
    }

    public int HP(){
        return this.currentHp;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "kd"){
            
            currentHp = currentHp - 10 ;
        }
        if (currentHp == 0 ){
            Destroy(GameObject.Find("Boss_src2"));
            Destroy(GameObject.FindWithTag("thanh_mau") );
        }
    }



    
    


    // private void OnTriggerEnter2D(Collider2D collision) {
    //     if (collision.gameObject.tag == "truoc_mat" ){
    //         Destroy(GameObject.Find("char"));
            
    //     }
        
    // }
}

