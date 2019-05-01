using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlower : MonoBehaviour
{
    public GameObject Broader;
    float timePassed, slower;

    public bool slowerCharacter;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Broader.SetActive(true);

            slowerCharacter = true;

            slower += Time.deltaTime;

            if(slower >= 5)
            {
                slowerCharacter = false;
                slower = 0;
            }
        }
    }
}
