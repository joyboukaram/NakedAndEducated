using System.Collections;
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


        if (bigger == true)
        {
            new_timePassed += Time.deltaTime;
            sphere.enabled = false;
            if (new_timePassed >= 5)
            {   
                
                GameObject[] enemy = GameObject.FindGameObjectsWithTag("FOV");
                bigger = false;
                foreach (GameObject C in enemy)
                {
                    C.GetComponent<EnemyController>();
                    C.transform.localScale = new Vector3(100.2f, 1.2f, 1f);
                }
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
            Broader.SetActive(true);
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("FOV");

            foreach (GameObject C in enemy)
            {   C.GetComponent<Renderer>().material = newMat;
                C.GetComponent<EnemyController>();

                C.transform.localScale += new Vector3(0.2f, 0,0.01f);

               
            }

        }

    }
}







