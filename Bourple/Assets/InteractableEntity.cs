using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class InteractableEntity : MonoBehaviour
{
    public GameColors.Colors entityColor;

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

    public bool isInteractable
    {
        get
        {
            if (entityColor == GameColors.Colors.NoColor)
            {
                return true;
            }
            else
            {
                return entityColor == colorUI.activeColor;
            }
        }
    }

    public Color displayColor
    {
        get
        {
            Color color = getColor(entityColor);
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

    private Color getColor(GameColors.Colors c)
    {
        switch (c)
        {
            case GameColors.Colors.Blue:
                return GameColors.blue;
            case GameColors.Colors.Red:
                return GameColors.red;
            case GameColors.Colors.Yellow:
                return GameColors.yellow;
            case GameColors.Colors.Purple:
                return GameColors.purple;
            case GameColors.Colors.Green:
                return GameColors.green;
            case GameColors.Colors.Orange:
                return GameColors.orange;
            case GameColors.Colors.NoColor:
            default:
                return GameColors.bgNoColor;

        }
    }
}
