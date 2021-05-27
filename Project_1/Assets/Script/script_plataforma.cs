using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_plataforma : MonoBehaviour{
    private Vector2 posInicial;
    private float cont;
    public float vel=1;
    public float desl =1;
    void Start()
    {
        posInicial = transform.position;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont = cont + desl * Time.deltaTime;
        float posX = Mathf.Sin(cont);
        float posY = Mathf.Cos(cont);

        transform.position = new Vector2(posInicial.x + posX, posInicial.y + posY);
        if(cont>2 * Mathf.PI){
            cont=0;
        }
    }
}
