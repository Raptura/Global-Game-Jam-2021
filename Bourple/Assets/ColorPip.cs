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

    public Color color
    {
        get
        {
            switch (pipColor)
            {
                case ColorPipColor.Blue:
                    return GameColors.blue;
                case ColorPipColor.Yellow:
                    return GameColors.yellow;
                case ColorPipColor.Red:
                    return GameColors.red;
                default:
                    return GameColors.noColor;
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
        spriteRenderer.color = color;
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
}
