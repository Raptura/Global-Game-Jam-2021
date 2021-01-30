using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class InteractableEntity : MonoBehaviour
{
    public enum EntityColor
    {
        NoColor,
        Red,
        Blue,
        Yellow,
        Purple,
        Green,
        Orange
    }
    public EntityColor entityColor;

    public enum EntityType
    {
        Object,
        Tilemap,
    }
    public EntityType entityType;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private ColorUI colorUI;
    private Collider2D col;
    private Collider2D playerCollider;

    public Color color
    {
        get
        {
            switch (entityColor)
            {
                case EntityColor.Blue:
                    return GameColors.blue;
                case EntityColor.Yellow:
                    return GameColors.yellow;
                case EntityColor.Red:
                    return GameColors.red;
                case EntityColor.Purple:
                    return GameColors.purple;
                case EntityColor.Green:
                    return GameColors.green;
                case EntityColor.Orange:
                    return GameColors.orange;
                case EntityColor.NoColor:
                default:
                    return GameColors.noColor;
            }
        }
    }

    public bool isInteractable
    {
        get
        {
            if (entityColor == EntityColor.NoColor)
            {
                return true;
            }
            else
            {
                return color == colorUI.activeColor;
            }
        }
    }

    public Color displayColor
    {
        get
        {
            return new Color(color.r, color.g, color.b, isInteractable ? 1f : 0.3f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        colorUI = FindObjectOfType<ColorUI>();

        switch (entityType)
        {
            case EntityType.Object:
                spriteRenderer = GetComponent<SpriteRenderer>();
                break;
            case EntityType.Tilemap:
                tilemap = GetComponent<Tilemap>();
                break;
        }

        col = GetComponent<Collider2D>();
        playerCollider = FindObjectOfType<CharacterColorController>().GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (entityType)
        {
            case EntityType.Object:
                spriteRenderer.color = displayColor;
                break;
            case EntityType.Tilemap:
                tilemap.color = displayColor;
                break;
        }

        Physics2D.IgnoreCollision(col, playerCollider, !isInteractable);
    }
}
