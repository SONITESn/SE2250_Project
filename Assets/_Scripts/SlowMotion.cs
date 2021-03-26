using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private float slowMo = 0.1f;
    private float normTime = 1.0f;
    private bool doSlowMo = false;

    [SerializeField] private PlayerController player;

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            if (doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.2f * Time.timeScale;
                doSlowMo = false;
            }
        }
        else
        {
            if (!doSlowMo)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.2f * Time.timeScale;
                doSlowMo = true;
            }
        }
    }
}
