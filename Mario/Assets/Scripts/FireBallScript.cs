using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speedUp;

      // nhạc 
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speedUp, 0);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "nen_dat"){
            speedUp = speedUp * 0.95f;
            rigidbody2D.velocity = new Vector2(speedUp, Mathf.Abs(speedUp));
        }

        if (collision.gameObject.tag == "boss"){
            GetComponent<BoxCollider2D>().isTrigger = true;
             Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "muc"){
            GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(GameObject.Find("muc"));
            PlaySound("Sounds/kill");
        }

        
    }
    public void SetScript(float value){
        speedUp = value;
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
            private void PlaySound(string name){
        AudioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }


}
