using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Sprite DaySprite;
    public Sprite NightSprite;

    private void OnEnable()
    {
        GameManager.OnDimensionChange += OnPillarChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPillarChange(GameManager._Dimensions dimension)
    {
        switch (dimension)
        {
            case GameManager._Dimensions.Day:
                break;

            case GameManager._Dimensions.Night:
                break;

            default:
                break;
        }
        print("boiiii");
        print(dimension.ToString());
    }

    private void OnDisable()
    {
        GameManager.OnDimensionChange -= OnPillarChange;
    }
}
