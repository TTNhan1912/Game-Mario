using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirahana : MonoBehaviour
{
    private Vector2 originalPosition; // vị trí ban đầu
    public float speed,height;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(GoUp());
    }

    IEnumerator GoUp(){
        // đi lên 
        while (true)
        {
            transform.position = new Vector2 (
                transform.position.x,
                transform.position.y + speed * Time.deltaTime);
            if (transform.position.y > originalPosition.y + height) break;
                yield return null;
        }
        StartCoroutine(GoDown());
    }
    IEnumerator GoDown(){
        bool stop = false;
            while (!stop){
                stop = true;
                yield return new WaitForSeconds(2);
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
        StartCoroutine(GoUp());
    }
}
