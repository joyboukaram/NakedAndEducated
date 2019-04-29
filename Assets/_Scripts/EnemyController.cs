using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //HUDController hud = GetComponent<HUDController>();

        //if(hud.timeLeft <= 120 && hud.timeLeft >= 60)
        //{
        //    CheckpointController checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckpointController>();
        //    checkpoint.ChangeSize();
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PlayerStats playerStats = collider.GetComponent<PlayerStats>();
            playerStats.TakeDamage();
            Destroy(gameObject);
        }
    }
}
