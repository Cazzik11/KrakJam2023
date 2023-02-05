using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    public float speed;
    public float distance;

    

    public Transform groundDetection;

    void Update(){
    
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        

    }
}
