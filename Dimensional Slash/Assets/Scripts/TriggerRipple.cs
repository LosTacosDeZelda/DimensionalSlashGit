using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRipple : MonoBehaviour
{
    public Material RippleMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //Activate ripple
            ActivateRipple();
        }
    }
    public float rippleExpansion = 0;
    void ActivateRipple()
    {
        rippleExpansion += 0.01f;

        RippleMat.SetFloat("RippleProgression", 1);
        
        
    }
}
