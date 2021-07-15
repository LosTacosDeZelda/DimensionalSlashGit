using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ludo : Ce script est pour toi, va falloir que tu set tes paramètres de FMOD ici.
public class SoundtrackSwitcher : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnDimensionChange += SwitchSoundtrack;
    }

    //La fonction SwitchSoundtrack est appelée quand le joueur change de dimension.
    //À toi de set les paramètres nécessaires de FMOD !
    void SwitchSoundtrack(GameManager._Dimensions dimension)
    {

    }

    private void OnDisable()
    {
        GameManager.OnDimensionChange -= SwitchSoundtrack;
    }
}
