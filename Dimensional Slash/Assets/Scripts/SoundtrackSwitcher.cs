using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ludo : Ce script est pour toi, va falloir que tu set tes paramètres de FMOD ici.
public class SoundtrackSwitcher : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string DayMusic = "";
    [FMODUnity.EventRef]
    public string NightMusic = "";

    private void OnEnable()
    {
        GameManager.OnDimensionChange += SwitchSoundtrack;
    }

    //La fonction SwitchSoundtrack est appelée quand le joueur change de dimension.
    //À toi de set les paramètres nécessaires de FMOD !
    void SwitchSoundtrack(GameManager._Dimensions dimension)
    {
        print((int)dimension);

        switch (dimension)
        {
            
            case GameManager._Dimensions.Day:
                break;
            case GameManager._Dimensions.Night:
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        
        GameManager.OnDimensionChange -= SwitchSoundtrack;
    }
}
