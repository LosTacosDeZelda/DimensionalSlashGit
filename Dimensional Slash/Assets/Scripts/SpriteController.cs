using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Animator myAnim;
    public AnimationClip[] animClips;
    public EntityStates currentState;
    public enum EntityStates
    {
        Idle,
        Walking,
        Special1,
        Special2,
        Special3
    }
    public bool canSwitchAnimState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeAnimationState(EntityStates state)
    {

    }

    void PlayAnimationClip(AnimationClip clip, bool lockAnim)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
