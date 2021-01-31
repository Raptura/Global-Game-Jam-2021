using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public GameColors.Colors color;

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

    public Color getColor(GameColors.Colors c)
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
            default:
                return GameColors.charNoColor;

        }
    }
}
