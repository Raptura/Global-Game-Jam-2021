using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
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

    private ColorUI colorUI;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
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

    // Start is called before the first frame update
    void Start()
    {
        colorUI = FindObjectOfType<ColorUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        playerCollider = FindObjectOfType<CharacterColorController>().GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //spriteRenderer.color = color;
        spriteRenderer.color = new Color(color.r, color.g, color.b, isInteractable ? 1f : 0.3f);
        Physics2D.IgnoreCollision(collider2D, playerCollider, !isInteractable);
    }
}
