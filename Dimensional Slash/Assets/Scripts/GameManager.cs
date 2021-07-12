using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public _Dimensions _currentDimension;
    public enum _Dimensions
    {
        Day,
        Night
    }

    public delegate void DimensionChangeHandler(_Dimensions nextDimension);
    public static DimensionChangeHandler OnDimensionChange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDimension(_Dimensions nextDimension)
    {
        //Invoke OnDimensionChange when the player changes dimensions, it will trigger calls on scripts who subscribed to it !
        OnDimensionChange.Invoke(nextDimension);
    }
}
