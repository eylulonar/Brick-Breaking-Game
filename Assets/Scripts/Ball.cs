using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRigidBody;
    public bool inPlay;
    public Transform paddle;
    public float ballSpeed;
    public Transform particles;
    public GameController gameController;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody= GetComponent<Rigidbody2D>();
        audioSource=GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
     if(gameController.gameOver){
        return;
    }
    
     if(!inPlay){
        transform.position = paddle.position;
     } 

    if(Input.GetButtonDown("Jump") && !inPlay){
        inPlay=true;
        ballRigidBody.AddForce(Vector2.up * ballSpeed);

    } 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("bottom")){
           Debug.Log("ball hit the bottom.");
           ballRigidBody.velocity=Vector2.zero;
           inPlay=false;
           gameController.LiveController(-1);
       } 
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("brick")){
            Bricks brickScript = other.gameObject.GetComponent<Bricks>();
            if(brickScript.brickHits>1 ){
                brickScript.BreakBrick();
            }
            
            else {
            Transform newParticle = Instantiate(particles, other.transform.position, other.transform.rotation);
            Destroy(newParticle.gameObject, 2.5f);
            gameController.ScoreController(brickScript.points);
            gameController.UpdateBrickCount();
            Destroy(other.gameObject);
            }
            audioSource.Play();

        }
        
    }

   
}
