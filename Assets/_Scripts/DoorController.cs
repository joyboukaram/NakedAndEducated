using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    public GameObject HUD;
    public GameObject player;


    public bool victory;

    private AudioSource audio;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.clip = audioClip;
            audio.Play();
            victory = true;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            Destroy(player.GetComponent<CharacterController>().source);
            HUD.GetComponent<HUDController>().enabled = false;
            HUDController hudController = HUD.GetComponent<HUDController>();
            hudController.Victory();




        }

    }

}
