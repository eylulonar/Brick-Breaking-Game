using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform particles;
    public GameController gamecont;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
     if(gamecont.gameOver){
        return;
    }
     if(!inPlay){
         transform.position = paddle.position;
     }  
    if(Input.GetButtonDown("Jump") && !inPlay){
        inPlay=true;
        rb.AddForce(Vector2.up * speed);

    } 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("bottom")){
           Debug.Log("ball hit the bottom.");
           rb.velocity=Vector2.zero;
           inPlay=false;
           gamecont.LiveController(-1);
       } 
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("brick")){
            Bricks brickScript = other.gameObject.GetComponent<Bricks>();
            if(brickScript.brickHits>1 ){

            }
            
            else {
            Transform newParticle = Instantiate(particles, other.transform.position, other.transform.rotation);
            Destroy(newParticle.gameObject, 2.5f);
            gamecont.ScoreController(brickScript.points);
            gamecont.UpdateBrickCount();
            Destroy(other.gameObject);}

        }
    }
}
