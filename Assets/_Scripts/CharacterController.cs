using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{

    public float maxSpeed;
    private HUDController hud;
    public float rotationspeed;
    public float shiftMaxSpeed;
    float timeLeft;
    float waitSprint;
    public GameObject pause;
    Animator playerAnimator;

    public int duration;
    float timePassed;

    private AudioSource source;
    public AudioClip hey;


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


        float speedHorizontal = Input.GetAxis("Horizontal");
        float speedVertical = Input.GetAxis("Vertical");

        float rotation = rotationspeed * Input.GetAxis("Mouse X");

        float result = hud.UpdateScore();

        if (result > 0)
        {
            if (pause.active == true)
            {
                FreezePosition();
                return;
            }

            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (speedVertical > 0 || speedHorizontal > 0))
            {
                timePassed += Time.deltaTime;
                Debug.Log(timePassed);
                if (timePassed > duration)
                {
                    StopCoroutine(Faster(speedHorizontal, speedVertical));

                }
                else
                    StartCoroutine(Faster(speedHorizontal, speedVertical));
            }

            if (timePassed > duration)
            {
                waitSprint -= Time.deltaTime;
                Debug.Log(waitSprint);
                if (waitSprint <= 0)
                {
                    timePassed = 0;
                    waitSprint = 0;
                }
            }


            transform.Rotate(0, rotation, 0);
            playerAnimator.SetFloat("verticalSpeed", (speedVertical));
            playerAnimator.SetFloat("horizontalSpeed", (speedHorizontal));
            transform.Translate(new Vector3(speedHorizontal * maxSpeed, 0, speedVertical * maxSpeed));

            //source.Play();
            CharacterSlower character = GetComponent<CharacterSlower>();
            //if(character.slowerCharacter == true)
            //{
            //    transform.Translate(new Vector3(speedHorizontal * 2, 0, speedVertical * 2));
            //    Debug.Log("hey");
            //}
            Debug.Log(character.slowerCharacter);

        }

        else
        {
            transform.Rotate(0, 0, 0);
            transform.Translate(new Vector3(0, 0, 0));
            playerAnimator.SetFloat("verticalSpeed", 0);
            playerAnimator.SetFloat("horizontalSpeed", 0);
        }

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
        playerAnimator.SetBool("goRight", false);
        playerAnimator.SetBool("goLeft", false);
        playerAnimator.SetBool("isWalking", false);
        playerAnimator.SetBool("isBackwards", false);
    }

    IEnumerator Faster(float speedHorizontal, float speedVertical)
    {
        transform.Translate(new Vector3(speedHorizontal * shiftMaxSpeed, 0, speedVertical * shiftMaxSpeed));


        yield return null;
    }
}
