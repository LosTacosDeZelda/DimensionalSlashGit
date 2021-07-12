using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public enum ColliderType
    {
        None,
        Circle,
        Box,
        Polygon
    }

    
    [Serializable]
    public class Dimension
    {
        public string name;
        public Sprite sprite;
        public ColliderType colType;
    }

    public Dimension[] DimensionsProperties;

    SpriteRenderer pillarSprite;
    Collider2D pillarCol;

    private void OnEnable()
    {
        GameManager.OnDimensionChange += OnPillarChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        pillarSprite = GetComponent<SpriteRenderer>();
        pillarCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPillarChange(GameManager._Dimensions dimension)
    {
        //Change sprite, remove collider
        pillarSprite.sprite = DimensionsProperties[(int)dimension].sprite;
        Destroy(GetComponent<Collider2D>());
        

        switch (DimensionsProperties[(int)dimension].colType)
        {
            case ColliderType.Circle:
                gameObject.AddComponent<CircleCollider2D>();
                break;
            case ColliderType.Box:
                gameObject.AddComponent<BoxCollider2D>();
                break;
            case ColliderType.Polygon:
                gameObject.AddComponent<PolygonCollider2D>();
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        GameManager.OnDimensionChange -= OnPillarChange;
    }
}
