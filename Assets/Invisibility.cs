using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{ 
    public GameObject ParticleParent;
    float timePassed;
    public float duration;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (ParticleParent.active)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= duration)
            {
                ParticleParent.SetActive(false);
                timePassed = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.tag == "Player")
        {
            ParticleParent.SetActive(true);
            CharacterController player = GameObject.Find("Player").GetComponent<CharacterController>();
            player.isVisible = false;
            
        }
    }
}
