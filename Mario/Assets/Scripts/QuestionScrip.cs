using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScrip : MonoBehaviour
{
    private Vector2 originalPosition;
    public Sprite newBlock;
    public float speed,height;
    private bool canChange;
    public GameObject item1, item2, item3;

    // nhạc 
    public AudioSource AudioSource;

    void Start() {
        originalPosition = transform.position;
        canChange = true;

        AudioSource =  GetComponent<AudioSource>();
    }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!canChange) return;
            if(collision.gameObject.tag =="player"){
                canChange = false;
                // Nảy lên rồi rớt xuống
                StartCoroutine(GoUpAndDown());
                // Chuyển thành hình khác
                GetComponent<SpriteRenderer>().sprite = newBlock;
                GetComponent<Animator>().enabled = false;
                // Phát nhạc
                PlaySound("Sounds/Coins");

            }
            
        }

    IEnumerator GoUpAndDown(){

        // đi lên 
        while (true)
        {
            transform.position = new Vector2 (
                transform.position.x,
                transform.position.y + speed * Time.deltaTime);
            if (transform.position.y > originalPosition.y + height) break;
                yield return null;
        }
        // đi xuống
        while (true){
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y - speed * Time.deltaTime);
            if (transform.position.y < originalPosition.y){ // Chặn lại không cho rớt thêm
                transform.position = originalPosition;
                break;
            }
            yield return null;

        }
        // Tạo vật phẩm
            GameObject newItem;
            int random = Random.Range(0,1);
                if(random == 0 )
                    newItem = Instantiate<GameObject>(item1);
                else if(random == 1 )
                    newItem = Instantiate<GameObject>(item2);
                else newItem = Instantiate<GameObject>(item3);
            newItem.transform.position = originalPosition;
            StartCoroutine(ItemGoUp(newItem));

    }
    private void PlaySound(string name){
        AudioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }
    IEnumerator ItemGoUp(GameObject newItem){
        while (true)
        {
            newItem.transform.position = new Vector2 (
                newItem.transform.position.x,
                newItem.transform.position.y + speed * Time.deltaTime);
            if (newItem.transform.position.y > originalPosition.y + 1) break;
                yield return null;
        }
    }


    

}
