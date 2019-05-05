using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private HUDController hud;
    public bool isVisible;
    public float rotationspeed;

    public float maxSpeed;
    public float shiftMaxSpeed;

    float timeLeft;
    float waitSprint;
    public GameObject pause;
    Animator playerAnimator;

    public int duration;
    float timePassed;

    public AudioSource source;
    public AudioClip walkingAudio;
    public Toggle toggle;

    public float speedHorizontal, speedVertical;
    GameObject[] game;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        shiftMaxSpeed = 15f;
        waitSprint = 5f;
        timeLeft = 3f;
        hud = GameObject.Find("HUD").GetComponent<HUDController>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {


        speedHorizontal = Input.GetAxis("Horizontal");
        speedVertical = Input.GetAxis("Vertical");

        float rotation = rotationspeed * Input.GetAxis("Mouse X");

        float result = hud.UpdateScore();

        if (result > 0)
        {
            source.pitch = 1.07f;
            if (pause.active == true)
            {
                FreezePosition();
                return;
            }

            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (speedVertical > 0 || speedHorizontal > 0))
            {
                timePassed += Time.deltaTime;

                if (timePassed > duration)
                {

                    StopCoroutine(Faster(speedHorizontal, speedVertical));

                }
                else
                {
                    source.pitch = 1.2f;
                    StartCoroutine(Faster(speedHorizontal, speedVertical));
                }
            }

            if (timePassed > duration)
            {
                waitSprint -= Time.deltaTime;

                if (waitSprint <= 0)
                {
                    timePassed = 0;
                    waitSprint = 0;
                }
            }

            if(GameObject.Find("Finish").GetComponent<DoorController>().victory == true)
            {

            }


            transform.Rotate(0, rotation, 0);
            playerAnimator.SetFloat("verticalSpeed", (speedVertical));
            playerAnimator.SetFloat("horizontalSpeed", (speedHorizontal));
            transform.Translate(new Vector3(speedHorizontal * maxSpeed, 0, speedVertical * maxSpeed));

            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            {

                source.Play();
            }
            else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && source.isPlaying)
                source.Pause();


        }
        else
        {
            transform.Rotate(0, 0, 0);
            transform.Translate(new Vector3(0, 0, 0));
            playerAnimator.SetFloat("verticalSpeed", 0);
            playerAnimator.SetFloat("horizontalSpeed", 0);
        }

    }

    public void dsad()
    {
        Debug.Log("OLA");
        PlayerMove();
    }

    public void PlayerMove()
    {

        transform.Translate(new Vector3(speedHorizontal * 0, 0, speedVertical * 0));
    }

    private float Sprint()
    {
        timeLeft -= 0.5f * Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            return timeLeft;
        }
        return timeLeft;
    }


    void FreezePosition()
    {
        transform.Rotate(0, 0, 0);
        transform.Translate(new Vector3(0, 0, 0));

    }


    IEnumerator Faster(float speedHorizontal, float speedVertical)
    {

        transform.Translate(new Vector3(speedHorizontal * shiftMaxSpeed, 0, speedVertical * shiftMaxSpeed));
        yield return null;
    }


    public void setVisible()
    {
        isVisible = true;
    }
    public void setInv()
    {
        isVisible = false;
    }

 

}
