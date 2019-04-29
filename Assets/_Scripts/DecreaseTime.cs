using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTime : MonoBehaviour
{
    public GameObject timeDecreaseText;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timeDecreaseText.SetActive(true);
            HUDController hud = GameObject.Find("HUD").GetComponent<HUDController>();
            hud.timeLeft -= 20;
            Destroy(gameObject);
        }
    }
}
