using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float randomAngle = 0f;
    public float turnSpeed;
    private float fov = 160f;
    private float next_angle = 45;
    public float variation_index;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeAngle();
        //change next angle according to timepassed using cha
    }
    void changeAngle(){
    gameObject.transform.Rotate(0,turnSpeed,0);
        float randomNumber = Random.value*1000/variation_index;
        if(randomNumber == 1)
            {
                gameObject.transform.Rotate(0,turnSpeed,0);
            }
    }
}
