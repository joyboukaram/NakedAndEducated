using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float randomAngle = 0f;
    public float turnSpeed;
    private float fov = 160f;
    private float next_angle;
    public float variation_index;
    private float wait_time = 2f;
    private bool wait = true;

    Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        next_angle = getNewAngle();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        changeAngle();
        //change next angle according to timepassed using cha
    }
    void changeAngle()
    {
        float num = next_angle - transform.eulerAngles.y;
        //    Debug.Log("Next Angle"+num);
        if (next_angle < transform.eulerAngles.y - 1 && next_angle > transform.eulerAngles.y + 1)
        {
            wait_time = wait_time - Time.deltaTime;
            if (wait_time == 0)
            {
                //    wait = false;
                wait_time = 2f;
                next_angle = getNewAngle();
            }
        }
        else
        {

            if (next_angle < transform.eulerAngles.y)
                gameObject.transform.Rotate(0, -turnSpeed, 0);
            if (next_angle > transform.eulerAngles.y)
                gameObject.transform.Rotate(0, +turnSpeed, 0);
            //         if(next_angle == transform.rotation.y)
            //            {
            //            wait=true;
            //            }
        }
    }
    static float getNewAngle()
    {
        float newangle = 160 * Random.value - 90;
        return newangle;

    }

  
}
