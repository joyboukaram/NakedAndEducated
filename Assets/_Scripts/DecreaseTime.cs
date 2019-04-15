using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HUDController hud = GameObject.Find("HUD").GetComponent<HUDController>();
            hud.timeLeft -= 20;
        }
    }
}
