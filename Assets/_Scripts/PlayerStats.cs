using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    int health;
    public GameObject HUD;
    public GameObject player;

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
        health -= 1;
        HUD.GetComponent<HUDController>().UpdateHealth(health);
        if (health == 0)
        {
            //SceneManager.LoadScene("GameOver");
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            HUD.GetComponent<HUDController>().enabled = false;
            HUD.GetComponent<HUDController>().GameOver();
            return;
        }

       

    }

}
