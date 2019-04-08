using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public GameObject HUD;


    // Start is called before the first frame update
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health -= 1;
            HUD.GetComponent<HUDController>().UpdateHealth(health);
        }
        if(health == 0)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
    }



}
