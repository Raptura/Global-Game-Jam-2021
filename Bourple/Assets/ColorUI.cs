using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField]
    private Image slot1, slot2, combinationSlot;

    public GameColors.Colors slot1Color { get; set; }
    public GameColors.Colors slot2Color { get; set; }
    public GameColors.Colors combinationSlotColor
    {
        get
        {
            if (slot1Color == GameColors.Colors.Red && slot2Color == GameColors.Colors.Blue
                || slot1Color == GameColors.Colors.Blue && slot2Color == GameColors.Colors.Red)
            {
                return GameColors.Colors.Purple;
            }
            else if (slot1Color == GameColors.Colors.Red && slot2Color == GameColors.Colors.Yellow
                || slot1Color == GameColors.Colors.Yellow && slot2Color == GameColors.Colors.Red)
            {
                return GameColors.Colors.Orange;
            }
            else if (slot1Color == GameColors.Colors.Blue && slot2Color == GameColors.Colors.Yellow
              || slot1Color == GameColors.Colors.Yellow && slot2Color == GameColors.Colors.Blue)
            {
                return GameColors.Colors.Green;
            }
            else
            {
                return GameColors.Colors.NoColor;
            }
        }
    }

    public GameColors.Colors activeColor
    {
        get
        {
            if (combinationSlotColor != GameColors.Colors.NoColor)
            {
                return combinationSlotColor;
            }
            else
            {
                if (slot1Color == slot2Color)
                {
                    return slot1Color;
                }
                else if (slot1Color == GameColors.Colors.Red && slot2Color == GameColors.Colors.NoColor
               || slot1Color == GameColors.Colors.NoColor && slot2Color == GameColors.Colors.Red)
                {
                    return GameColors.Colors.Red;
                }
                else if (slot1Color == GameColors.Colors.Yellow && slot2Color == GameColors.Colors.NoColor
                    || slot1Color == GameColors.Colors.NoColor && slot2Color == GameColors.Colors.Yellow)
                {
                    return GameColors.Colors.Yellow;
                }
                else if (slot1Color == GameColors.Colors.Blue && slot2Color == GameColors.Colors.NoColor
                  || slot1Color == GameColors.Colors.NoColor && slot2Color == GameColors.Colors.Blue)
                {
                    return GameColors.Colors.Blue;
                }
                else
                {
                    return GameColors.Colors.NoColor;
                }
            }
        }
    }

    public bool slot1Selected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        slot1Color = GameColors.Colors.NoColor;
        slot2Color = GameColors.Colors.NoColor;
        slot1Selected = true;
    }

    // Update is called once per frame
    void Update()
    {
        slot1.color = getColor(slot1Color);
        slot2.color = getColor(slot2Color);
        combinationSlot.color = getColor(combinationSlotColor);


        var smallScale = new Vector2(0.5f, 0.5f);
        var selectedScale = new Vector2(1, 1);
        if (slot1Selected)
        {
            slot1.rectTransform.localScale = selectedScale;
            slot2.rectTransform.localScale = smallScale;
        }
        else
        {
            slot2.rectTransform.localScale = selectedScale;
            slot1.rectTransform.localScale = smallScale;
        }
    }

    public void updateColor(GameColors.Colors color)
    {
        if (slot1Selected)
        {
            slot1Color = color;
        }
        else
        {
            slot2Color = color;
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
            case GameColors.Colors.Purple:
                return GameColors.purple;
            case GameColors.Colors.Green:
                return GameColors.green;
            case GameColors.Colors.Orange:
                return GameColors.orange;
            case GameColors.Colors.NoColor:
            default:
                return GameColors.charNoColor;

        }
    }
}
