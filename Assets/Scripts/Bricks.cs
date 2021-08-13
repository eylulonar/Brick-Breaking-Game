using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    // Start is called before the first frame update
    public int points;
    public int brickHits;
    public Sprite hitSprite;
    //public float fallSpeed = 8.0f;
    
     public void BreakBrick(){
         brickHits--;
         GetComponent<SpriteRenderer>().sprite= hitSprite;
     }

     
}
