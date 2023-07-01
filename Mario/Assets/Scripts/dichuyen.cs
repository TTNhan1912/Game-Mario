using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dichuyen : MonoBehaviour
{

    public Animator ani;
    public bool isRight = true;
    public bool nen_dat ;   
    // public Animator animator;
    public float Run;
    public bool isJump;
    public Rigidbody2D rigidbody2d;

    public bool isPause = false;
      // nhạc 
    public AudioSource AudioSource;

    // time
    public int time; // time tính bằng giây
    public Text timeText;
    private bool isAlive; // kiểm tra nhân vật còn tương tác

    // viên đạn
    public GameObject fireball;

        //menu
        private bool isMenu;
        public GameObject menu;
        public Text menuTimeText;

    private bool isWin;
    public GameObject Win;
        public Text TextWin;



    // mạng
    private int life;



    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        Run = 0;
        isJump = false;
        AudioSource = GetComponent<AudioSource>();


        // time
        isAlive = true;
        time = 0 ;
        timeText.text = time + "Time : ";
        StartCoroutine(Updatetime());

        isMenu = false;
        isWin = false;

        life = 3;   
        
        
    }
    // cập nhật time 
    IEnumerator Updatetime(){
        while (isAlive)
        {
            time++;
            timeText.text =  "00" + time;
            yield return new WaitForSeconds(1);            
        }
    } 

    // Update is called once per frame
    void Update()
    {

        // ani.SetFloat("Run",Run);
        // ani.SetBool("isJump",isJump);
        if(Input.GetKey(KeyCode.RightArrow)){
            isRight = true;

            ani.SetBool("isRunning", true);
            ani.Play("dichuyen");

            transform.Translate(Time.deltaTime * 5, 0, 0);
            
            
            transform.localScale = new Vector3(1F, 1F, 1F);
        }else{
            ani.SetBool("isRunning", false);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            isRight = false;

            ani.SetBool("isRunning",true);
            ani.Play("dichuyen");

            transform.Translate(-Time.deltaTime * 5, 0, 0 );
            transform.localScale = new Vector3(-1F,1F,1F);  
        }
        if (Input.GetKey(KeyCode.Space)){

            if(nen_dat == true ){
                ani.SetBool("isJump",false);
                ani.Play("nhay");
                rigidbody2d.AddForce(new Vector2(0,600));
                nen_dat = false;
                PlaySound("Sounds/smb3_jump");
                
            }
        }
        // if (Input.GetKey(KeyCode.Space)){
        //      ani.SetBool("isJump",false);
        // }

        // bắn đạn
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject fire = Instantiate(fireball);
            fire.transform.position = new Vector3(
                transform.position.x + (isRight ? 0.8f : -0.8f),
                transform.position.y,
                transform.position.z
            );
        fire.GetComponent<FireBallScript>().SetScript(
            isRight ? 10 : -10);

        }


        if (Input.GetKeyDown(KeyCode.P)){
            if(!isMenu){
                isMenu = true;
                menu.SetActive(true);
                Time.timeScale = 0;
                menuTimeText.text = "Pause Game " ;
            }else{
                isMenu = false;
                menu.SetActive(false);
                Time.timeScale = 1;
            }
        
            
        }



        }
        private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "nen_dat"){
            nen_dat = true;
            }
            if (collision.gameObject.tag == "qua_man"){
                SceneManager.LoadScene("Man_2");
            }
            if(collision.gameObject.tag == "Win")
        {
            isWin= true;
            Win.SetActive(true);
            GetComponent<AudioSource>().mute = true;
            Debug.Log("Winnnnnnnnnnnnnnn");
        }
        if (isWin)
        {
            PlaySound("Sounds/Win");
            Debug.Log("Phat Nhac Winnnnn");
        }

            
        }
        private void PlaySound(string name){
        AudioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }

    public void QuitGame(){
        Application.Quit();
    }
    public void ResumeGame(){
        isMenu = false;
        menu.SetActive(false);
        Time.timeScale = 1;
  
    }
    public void NextScreen(){
        SceneManager.LoadScene(1);
    }

    public void lifeCheck()
    {

       
         if (life == 0)
        {
            SceneManager.LoadScene(0);
        }

    }

}
        


        
    

