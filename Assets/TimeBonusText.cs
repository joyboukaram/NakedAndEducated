﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonusText : MonoBehaviour
{
    float timePassed =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
            if (timePassed >= 1.5f)
            {
                Destroy(gameObject);
            }
    }
}
