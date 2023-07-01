using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kill_quai : MonoBehaviour
{
    public static int diemTong = 0 ;
    public GameObject diemtext;
    // public GameObject PSCoin;

      // nhạc 
    public AudioSource AudioSource;
    
    // // life
    // private int life; 
    // public Text lifeText;

    

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        CongDiem(0);

        // life = 3;
        // lifeText.text = life + "";

        // originalPosition = transform.localPosition;

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     public void CongDiem(int DiemCong){
            diemTong += DiemCong;
            diemtext.GetComponent<Text>().text = "000" + diemTong.ToString(); 

    }


    private void OnTriggerEnter2D(Collider2D collision){
        string name_quai = collision.attachedRigidbody.gameObject.name;
        string name_vang = collision.attachedRigidbody.gameObject.name; 
        // if(collision.gameObject.tag == "ben_trai" ){
        //     Destroy(GameObject.Find("char"));
        //     // LifeRespawn();

        //     PlaySound("Sounds/die");
        // }
        if(collision.gameObject.tag == "ben_tren"){

            CongDiem(3);
            Destroy(GameObject.Find(name_quai));
            PlaySound("Sounds/kill");
        }
        if (collision.gameObject.tag == "vang"){
                
                Destroy(GameObject.Find(name_vang));
                CongDiem(1);
                PlaySound("Sounds/smb3_coin");
                

            }
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {    
        Vector2 direction = collision.GetContact(0).normal;
         if(Mathf.Round(direction.x) == 1 || Mathf.Round(direction.x) == -1){
            if (collision.gameObject.tag == "rua")
            {
                Destroy(gameObject);
                PlaySound("Sounds/kill");
            }
            
        }
        
    }
    

    private void PlaySound(string name){
        AudioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }

    // private void LifeRespawn(){
    //     if(life >= 1){
    //         life--;
    //         lifeText.text = life + "";
    //         transform.localPosition = originalPosition;
            
    //     }else{
    //         // Game Over
    //         Debug.Log("Game Over");
    //     }
        
    // }
    

}
