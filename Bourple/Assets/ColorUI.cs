using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [HideInInspector]
    public Color noColor, red, blue, yellow, purple, green, orange;

    public Image slot1, slot2, combinationSlot;

    public Color slot1Color { get; set; }
    public Color slot2Color { get; set; }
    public Color combinationSlotColor
    {
        get
        {
            if (slot1Color == red && slot2Color == blue
                || slot1Color == blue && slot2Color == red)
            {
                return purple;
            }
            else if (slot1Color == red && slot2Color == yellow
                || slot1Color == yellow && slot2Color == red)
            {
                return orange;
            }
            else if (slot1Color == blue && slot2Color == yellow
              || slot1Color == yellow && slot2Color == blue)
            {
                return green;
            }
            else
            {
                return noColor;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        setupColors();
        slot1Color = yellow;
        slot2Color = red;
    }

    // Update is called once per frame
    void Update()
    {
        slot1.color = slot1Color;
        slot2.color = slot2Color;
        combinationSlot.color = combinationSlotColor;
    }

    void setupColors()
    {
        noColor = Color.white;
        red = new Color(234f / 255, 59f / 255f, 41f / 255f, 1);
        blue = new Color(28f / 255f, 135 / 255f, 243f / 255f, 1);
        yellow = new Color(245f / 255f, 234 / 255f, 89 / 255f, 1);

        //These are the combo colors
        purple = new Color(120f / 255f, 79f / 255f, 192f / 255f, 1);
        green = new Color(43f / 255f, 224f / 255f, 103f / 255f, 1);
        orange = new Color(255f / 255f, 154f / 255f, 0f / 255f, 1);

    }
}
