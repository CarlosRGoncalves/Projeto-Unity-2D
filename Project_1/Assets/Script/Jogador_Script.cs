using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jogador_Script : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJump;
    public bool dJump;
    private Animator animator;
    private Rigidbody2D rig;
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal")>0f)
        {
                    animator.SetBool("Andar", true);
                    transform.eulerAngles = new Vector3(0f,0f,0f);

        }
        if(Input.GetAxis("Horizontal")<0f)
        {
                    animator.SetBool("Andar", true);
                    transform.eulerAngles = new Vector3(0f,180,0f);
        }
        if(Input.GetAxis("Horizontal")==0f)
        {
                    animator.SetBool("Andar", false);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pausado)
            {
                pausado=false;
                Time.timeScale = 1;
                controlador_game.instance.ShowContinue();

            }
            else
            {
                pausado=true;
                Time.timeScale = 0;
                controlador_game.instance.ShowPause();

            }

        }
        /*
        rig.velocity = new Vector2(x*Speed,rig.velocity.y);
        if(Input.GetAxis("Horizontal")>0)
        {
                    animator.SetBool("Andar", true);
                    transform.eulerAngles = new Vector2(0f,0f);

        }
        if(Input.GetAxis("Horizontal")<0)
        {
                    animator.SetBool("Andar", true);
                    transform.eulerAngles = new Vector2(0f,180);
        }
        if(Input.GetAxis("Horizontal")==0)
        {
                    animator.SetBool("Andar", false);
        }*/
        
    }
    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!isJump){
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                dJump = true;
                animator.SetBool("Pular",true);
            }else{
                if(dJump){
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    dJump =false;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJump=false;
            animator.SetBool("Pular",false);

        }
        if(collision.gameObject.tag == "Madeiras"){
           controlador_game.instance.ShowGameOver();
           Destroy(gameObject);

        }
        if(collision.gameObject.tag == "final"){
           controlador_game.instance.ShowFinish();
           Destroy(gameObject);

        }
       
    }
    void OnCollisionExit2D(Collision2D collision){
         if(collision.gameObject.layer == 8){
            isJump=true;
        }
    }

}
