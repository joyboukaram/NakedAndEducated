using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float angle = 0f;
    public float turnSpeed;
    private float fov = 160f;
    private float origin = 0f;

    Animator enemyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        origin = angle;
        angle = getNewAngle();

    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(angle+" euler: "+gameObject.transform.eulerAngles.y);
        if(angle<=gameObject.transform.eulerAngles.y+3 && angle>=gameObject.transform.eulerAngles.y-3){
            origin = angle;
            angle = getNewAngle();
            }
        else {
        if(origin-angle>180)
        gameObject.transform.Rotate(0,returnSign(angle)*0.1f*turnSpeed,0);
        else gameObject.transform.Rotate(0,returnSign(angle)*0.1f*turnSpeed,0);
        
        }
    }
    float getNewAngle()
    {
        float newangle = fov * Random.value;
        return newangle;

    }
    float returnSign(float angle){
        if (angle-80>0)
            return 1;
        else return -1;
    }
  
}
