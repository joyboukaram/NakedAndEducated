using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTime : MonoBehaviour
{
    public GameObject timeDecreaseText;
    float timePassed;
    bool bigger;
    float new_timePassed;
    SphereCollider sphere;

    public AudioClip audioClip;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDecreaseText.active)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 1.5f)
            {
                timeDecreaseText.SetActive(false);
                timePassed = 0;
            }
        }

        if (bigger == true)
        {
            new_timePassed += Time.deltaTime;
            Debug.Log(new_timePassed);
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
            timeDecreaseText.SetActive(true);
            HUDController hud = GameObject.Find("HUD").GetComponent<HUDController>();
            hud.timeLeft -= 20;
        }
    }
}
