using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private GameObject closest;
    private bool destroy = false;
    public float time = 2f;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
        if(destroy){
            if(time <= 0){
                Destroy(closest);
                Destroy(gameObject);
            }
            else{
            time = time - Time.deltaTime;
            }
        }
    }
     private void OnTriggerEnter(Collider collider){
        if(collider.tag =="Player" && destroy == false)
            {
            audio.Play();
                closest.transform.GetChild(0).gameObject.SetActive(false);
                closest.transform.GetChild(1).gameObject.SetActive(false);
                closest.transform.GetChild(2).gameObject.SetActive(false);
                closest.transform.GetChild(3).gameObject.SetActive(true);
                destroy = true;
            }
    }
    void kill(){
                
              
    }
}
