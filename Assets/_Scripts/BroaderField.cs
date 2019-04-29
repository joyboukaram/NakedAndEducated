using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroaderField : MonoBehaviour
{

    public GameObject Broader;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {

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
        //Debug.Log(Broader.active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Broader.SetActive(true);
            CheckpointController checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckpointController>();
            checkpoint.ChangeSize();
            Destroy(gameObject);
           
        }
    }


}
