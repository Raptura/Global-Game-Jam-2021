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

    private TileBase[] outlineSet, regularSet;
    [SerializeField]
    private Sprite outlineSprite, enabledSprite;


    private ColorUI colorUI;
    private Collider2D col;
    private Collider2D playerCollider;


    private bool _isInteractable = true;
    public bool isInteractable
    {
        get
        {
            return _isInteractable;
        }
        set
        {
            if (_isInteractable != value)
            {
                if (entityType == EntityType.Tilemap)
                    swapTiles();
                else if (entityType == EntityType.Object)
                    swapSprite();
            }

            _isInteractable = value;
        }
    }

    public Color displayColor
    {
        get
        {
            Color color = getColor(entityColor);
            //return new Color(color.r, color.g, color.b, isInteractable ? 1f : 0.3f);
            return getColor(entityColor);
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
        outlineSet = Resources.LoadAll<TileBase>("Environment/TilesOutline");
        regularSet = Resources.LoadAll<TileBase>("Environment/Tiles");
        isInteractable = true;
    }

    // Update is called once per frame
    void Update()
    {
        isInteractable = (entityColor == colorUI.activeColor) || (entityColor == GameColors.Colors.NoColor);

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

    private void swapTiles()
    {
        if (regularSet.Length != outlineSet.Length)
        {
            Debug.LogError("Issue with loading tiles! Tiles do not have same length");
            return;
        }

        for (int i = 0; i < regularSet.Length; i++)
        {
            if (isInteractable)
                tilemap.SwapTile(regularSet[i], outlineSet[i]);
            else
                tilemap.SwapTile(outlineSet[i], regularSet[i]);
        }

    }

    private void swapSprite()
    {
        if (isInteractable)
            spriteRenderer.sprite = outlineSprite;
        else
        {
            spriteRenderer.sprite = enabledSprite;
        }

    }
}
