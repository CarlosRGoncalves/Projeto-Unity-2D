using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolim : MonoBehaviour
{
    private Animator mudar;
    void Start(){
        mudar = GetComponent<Animator>();
    }
    public float Forca = 25;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            mudar.SetTrigger("pular");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,Forca), ForceMode2D.Impulse);
        }
    }
}
