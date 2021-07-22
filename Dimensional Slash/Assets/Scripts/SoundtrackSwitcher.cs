using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ludo : Ce script est pour toi, va falloir que tu set tes paramètres de FMOD ici.
public class SoundtrackSwitcher : MonoBehaviour
{
    //Les events du Jukebox et de l'Ambiance sonore
    //public FMODUnity.StudioEventEmitter SoundEvent;
    [FMODUnity.EventRef]
    public string SoundEvent = "";

    [FMODUnity.EventRef]
    public List<string> Events;

    FMOD.Studio.EventInstance EventInstance;
    private void OnEnable()
    {
        GameManager.OnDimensionChange += SwitchSoundtrack;
        //créer une instance de l'event proposé et le faire jouer manuellement
        EventInstance = FMODUnity.RuntimeManager.CreateInstance(SoundEvent);
        EventInstance.start();
    }

    //La fonction SwitchSoundtrack est appelée quand le joueur change de dimension.
    //À toi de set les paramètres nécessaires de FMOD !
    void SwitchSoundtrack(GameManager._Dimensions dimension)
    {
        switch (dimension)
        {
            case GameManager._Dimensions.Day:
                SoundEvent = "event:/Ambiance/Wind";
                StartCoroutine(FadeOut());
                break;
            case GameManager._Dimensions.Night:
                SoundEvent = "event:/Ambiance/Fire";
                StartCoroutine(FadeOut());
                break; 
            default:
                break;
        }
    }
    // On attend que le fade out termine avant de jouer le nouveau son
    IEnumerator FadeOut()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Event = SoundEvent;
        EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        yield return new WaitForSeconds(5f);
        EventInstance.release();
        // EventInstance.clearHandle();
        EventInstance.start();
    }

    private void OnDisable()
    {
        GameManager.OnDimensionChange -= SwitchSoundtrack;
    }
}
