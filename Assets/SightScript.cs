using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{

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
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            
            CharacterController player = GameObject.Find("Player").GetComponent<CharacterController>();
if(player.isVisible){
            
            PlayerStats playerStats = collider.GetComponent<PlayerStats>();
            playerStats.TakeDamage();}
            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        audio.Play();
        CharacterController player = GameObject.Find("Player").GetComponent<CharacterController>();
        player.isVisible = false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        player.isVisible = true;
        yield return null;

    }
}
