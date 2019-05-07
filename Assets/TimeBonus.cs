using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    public GameObject timeIncreaseText;
    float timePassed;
    public AudioClip audioClip;
    private AudioSource audio;

    bool bigger;
    float new_timePassed;
    SphereCollider sphere;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIncreaseText.active)
        {
            timePassed += Time.deltaTime;
           
            if (timePassed >= 1.5f)
            {
                timeIncreaseText.SetActive(false);
                timePassed = 0;

            }
        }

        if (bigger == true)
        {
            new_timePassed += Time.deltaTime;
            sphere.enabled = false;
            if (new_timePassed >= 0.7f)
            {
                Destroy(gameObject);
                bigger = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bigger = true;
            audio.clip = audioClip;
            audio.Play();
            timeIncreaseText.SetActive(true);
            HUDController hud = GameObject.Find("HUD").GetComponent<HUDController>();
            hud.timeLeft += 20;

        }
    }

}
