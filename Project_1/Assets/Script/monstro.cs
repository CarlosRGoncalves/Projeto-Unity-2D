using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class monstro : MonoBehaviour
{
    public GameObject gameOver;

    private Rigidbody2D rig;
    private Animator anim;
    public float vel;
    public Transform dir;
    public Transform esq;
    public Transform cabeca;
    private bool colid;
    public LayerMask layer;
    public BoxCollider2D box;
    public CircleCollider2D circle;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(vel, rig.velocity.y);
        colid = Physics2D.Linecast(dir.position, esq.position,layer);

        if(colid){
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            vel *= -1f;
       }
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player"){
            float dir = col.contacts[0].point.y - cabeca.position.y;
            if(dir>0){
                vel =0;
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                box.enabled =false;
                circle.enabled =false;
                Destroy(gameObject, 0.1f);
            }else{
               
                controlador_game.instance.ShowGameOver();
                Destroy(col.gameObject);

            }
        }
        
    }
}
