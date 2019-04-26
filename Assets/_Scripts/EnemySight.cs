using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	
	private SphereCollider col;
	private Animator anim;
	public GameObject player;
	private Animator playerAnim;

	void Awake(){

	col = GetComponent<SphereCollider>();
	anim =  GetComponent<Animator>();
	playerAnim = player.GetComponent<Animator>();
	
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			if(angle<fieldOfViewAngle*0.5f)
			{
				RaycastHit hit;
			
				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;
						PlayerStats playerStats = other.GetComponent<PlayerStats>();
           					playerStats.TakeDamage();
            					Destroy(gameObject);
					}
				}
			}
		}

	}
}
