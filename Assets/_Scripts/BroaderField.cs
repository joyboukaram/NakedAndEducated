﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroaderField : MonoBehaviour
{
    public int i = 50;
    public GameObject Broader;
    float timePassed;
    float new_timePassed;
    bool bigger;
    public Material newMat;

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
        if (Broader.active)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 1.5f)
            {
                Broader.SetActive(false);
                timePassed = 0;
            }
        }


      

    }

    private void OnTriggerEnter(Collider other)
    {   
        
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().TakeDamage();
            Destroy(gameObject);

        }

    }
}







