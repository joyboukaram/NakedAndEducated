using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void OnTriggerEnter(Collider collider){
        if(collider.tag =="Player")
            {
                PlayerStats playerStats = collider.GetComponent<PlayerStats>();
                playerStats.TakeDamage();
            }
    }
}
