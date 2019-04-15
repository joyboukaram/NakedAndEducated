using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public GameObject [] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            foreach (GameObject G in checkpoints)
                G.SetActive(true);
        }
    }

    public void ChangeSize()
    {
        foreach (GameObject G in checkpoints)
        {
            G.transform.localScale += new Vector3(50, 0, 50);
        }
    }

}
