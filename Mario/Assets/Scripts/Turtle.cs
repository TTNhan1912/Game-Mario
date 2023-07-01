using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public float left, right;
    public float speed;
    public bool isRight;

    public Sprite newSprite; // Hình mới
    private bool isAlive;

    public float speedUp; 
    public float height;
    private Vector2 originalPosition; // vị trí ban đầu'

    // nhạc 
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (!isAlive) return; // nếu đã chết thì đứng yên

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

        int random = Random.Range(1,10);
    
    }

        private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "player"){
            var direction = collision.GetContact(0).normal;
            // bị đạp
                if (Mathf.Round(direction.y) == -1){
                    // đổi hình 
                    GetComponent<SpriteRenderer>().sprite = newSprite;
                    // tắt animation
                    GetComponent<Animator>().enabled = false;
                    // tắt chuyển động
                    isAlive = false;
                    // nảy lên, rớt xuống
                    originalPosition = transform.position;
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    StartCoroutine(GoUp());
                    // biến mất
                    Destroy(gameObject, 2);
                    PlaySound("Sounds/kill");
                    
                }
        }
        if (collision.gameObject.tag == "kd")
        {
            var direction = collision.GetContact(0).normal;
            // bị đạp
            
            
                // đổi hình 
                GetComponent<SpriteRenderer>().sprite = newSprite;
                // tắt animation
                GetComponent<Animator>().enabled = false;
                // tắt chuyển động
                isAlive = false;
                // nảy lên, rớt xuống
                originalPosition = transform.position;
                GetComponent<BoxCollider2D>().isTrigger = true;
                StartCoroutine(GoUp());
                // biến mất
                Destroy(gameObject, 2);
                PlaySound("Sounds/kill");

            
        }
    }
    IEnumerator GoUp(){
        // đi lên 
        while (true)
        {
            transform.position = new Vector2 (
                transform.position.x,
                transform.position.y + speedUp * Time.deltaTime);
            if (transform.position.y > originalPosition.y + height) break;
                yield return null;
        }
    }
    private void PlaySound(string name){
        audioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }
}
