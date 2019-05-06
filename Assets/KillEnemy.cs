using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private GameObject closest;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        int i =0;
        float min =0;
        float dist;
        
          foreach (GameObject C in enemy)
                {
                    dist = Vector3.Distance(C.transform.position, transform.position);
                    if(min > dist || min ==0 ){
                        min = Vector3.Distance(C.transform.position, transform.position);
                        closest = C;
                        }
                    
                }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider collider){
        if(collider.tag =="Player")
            {
                Destroy(gameObject);
                closest.transform.GetChild(0).gameObject.SetActive(false);
                closest.transform.GetChild(1).gameObject.SetActive(false);
                closest.transform.GetChild(2).gameObject.SetActive(false);
                closest.transform.GetChild(3).gameObject.SetActive(true);
                closest.transform.GetChild(4).gameObject.SetActive(true);
                Destroy(closest);
            }
    }
    void kill(){
                
              
    }
}
