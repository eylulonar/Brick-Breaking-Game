using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameController gameController;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * paddleSpeed);

        if(transform.position.x < leftScreenEdge){
           transform.position = new Vector2(leftScreenEdge, transform.position.y);

        }

        if(transform.position.x > rightScreenEdge){
           transform.position = new Vector2(rightScreenEdge, transform.position.y);

        }
        
    }
}
