using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeProfileSwapper : MonoBehaviour
{
    public VolumeProfile DayProfile;
    public VolumeProfile NightProfile;

    Volume globalVolume;

    private void OnEnable()
    {
        GameManager.OnDimensionChange += SwapProfile;
    }

    // Start is called before the first frame update
    void Start()
    {
        globalVolume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwapProfile(GameManager._Dimensions dimension)
    {
        switch (dimension)
        {
            case GameManager._Dimensions.Day:
                globalVolume.profile = DayProfile;
                break;

            case GameManager._Dimensions.Night:
                globalVolume.profile = NightProfile;
                break;

            default:
                break;
        }
    }

    private void OnDisable()
    {
        GameManager.OnDimensionChange -= SwapProfile;
    }
}
