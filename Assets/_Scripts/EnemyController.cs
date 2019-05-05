using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private AudioSource audio;

    float new_timePassed;
    bool bigger;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(bigger == true)
        {
            new_timePassed += Time.deltaTime;

            if(new_timePassed >= 2)
            {
                Destroy(gameObject);
                new_timePassed = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            bigger = true;
            audio.Play();
            PlayerStats playerStats = collider.GetComponent<PlayerStats>();
            playerStats.TakeDamage();

        }
    }

 
}
