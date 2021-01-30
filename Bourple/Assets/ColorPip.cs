using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public enum ColorPipColor
    {
        Blue,
        Yellow,
        Red
    }
    public ColorPipColor pipColor;

    public GameColors.Colors color
    {
        get
        {
            switch (pipColor)
            {
                case ColorPipColor.Blue:
                    return GameColors.Colors.Blue;
                case ColorPipColor.Yellow:
                    return GameColors.Colors.Yellow;
                case ColorPipColor.Red:
                    return GameColors.Colors.Red;
                default:
                    return GameColors.Colors.NoColor;
            }
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = getColor(color);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterController2D>())
        {
            try
            {
                FindObjectOfType<ColorUI>().updateColor(color);
            }
            catch
            {
            }
        }
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
            case GameColors.Colors.NoColor:
            default:
                return GameColors.charNoColor;

        }
    }
}
