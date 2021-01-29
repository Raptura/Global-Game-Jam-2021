using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField]
    private Image slot1, slot2, combinationSlot;

    public Color slot1Color { get; set; }
    public Color slot2Color { get; set; }
    public Color combinationSlotColor
    {
        get
        {
            if (slot1Color == GameColors.red && slot2Color == GameColors.blue
                || slot1Color == GameColors.blue && slot2Color == GameColors.red)
            {
                return GameColors.purple;
            }
            else if (slot1Color == GameColors.red && slot2Color == GameColors.yellow
                || slot1Color == GameColors.yellow && slot2Color == GameColors.red)
            {
                return GameColors.orange;
            }
            else if (slot1Color == GameColors.blue && slot2Color == GameColors.yellow
              || slot1Color == GameColors.yellow && slot2Color == GameColors.blue)
            {
                return GameColors.green;
            }
            else
            {
                return GameColors.noColor;
            }
        }
    }

    public Color activeColor
    {
        get
        {
            if (combinationSlotColor != GameColors.noColor)
            {
                return combinationSlotColor;
            }
            else
            {
                if (slot1Color == GameColors.red && slot2Color == GameColors.noColor
               || slot1Color == GameColors.noColor && slot2Color == GameColors.red)
                {
                    return GameColors.red;
                }
                else if (slot1Color == GameColors.yellow && slot2Color == GameColors.noColor
                    || slot1Color == GameColors.noColor && slot2Color == GameColors.yellow)
                {
                    return GameColors.yellow;
                }
                else if (slot1Color == GameColors.blue && slot2Color == GameColors.noColor
                  || slot1Color == GameColors.noColor && slot2Color == GameColors.blue)
                {
                    return GameColors.blue;
                }
                else
                {
                    return GameColors.noColor;
                }
            }
        }
    }

    public bool slot1Selected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        slot1Color = GameColors.noColor;
        slot2Color = GameColors.noColor;
        slot1Selected = true;
    }

    // Update is called once per frame
    void Update()
    {
        slot1.color = slot1Color;
        slot2.color = slot2Color;
        combinationSlot.color = combinationSlotColor;
    }

    public void updateColor(Color color)
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
}
