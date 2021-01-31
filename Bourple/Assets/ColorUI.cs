using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField]
    private Image slot1Jar, slot1, slot1Fill, slot2Jar, slot2, slot2Fill, combinationSlot;
    [SerializeField]
    private Sprite jarOpen, jarClosed;

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
        slot1Fill.color = slot1.color;
        slot2.color = getColor(slot2Color);
        slot2Fill.color = slot2.color;
        combinationSlot.color = getColor(activeColor);

        if (slot1Color == GameColors.Colors.NoColor)
        {
            slot1.gameObject.SetActive(false);
            slot1Fill.gameObject.SetActive(false);
        }
        else
        {
            slot1.gameObject.SetActive(true);
            slot1Fill.gameObject.SetActive(true);
        }

        if (slot2Color == GameColors.Colors.NoColor)
        {
            slot2.gameObject.SetActive(false);
            slot2Fill.gameObject.SetActive(false);
            
        }
        else
        {
            slot2.gameObject.SetActive(true);
            slot2Fill.gameObject.SetActive(true);
        }


        if (slot1Selected)
        {
            slot1Jar.sprite = jarOpen;
            slot2Jar.sprite = jarClosed;

            slot1Jar.transform.SetSiblingIndex(1);
            slot1.transform.SetSiblingIndex(2);
            slot2Jar.transform.SetSiblingIndex(2);
            slot2.transform.SetSiblingIndex(1);
        }
        else
        {
            slot2Jar.sprite = jarOpen;
            slot1Jar.sprite = jarClosed;
            slot1Jar.transform.SetSiblingIndex(2);
            slot1.transform.SetSiblingIndex(1);
            slot2Jar.transform.SetSiblingIndex(1);
            slot2.transform.SetSiblingIndex(2);

        }
    }

    public void updateColor(GameColors.Colors color)
    {

        if (color == GameColors.Colors.Green)
        {
            slot1Color = GameColors.Colors.Blue;
            slot2Color = GameColors.Colors.Yellow;
        }
        else if (color == GameColors.Colors.Purple)
        {
            slot1Color = GameColors.Colors.Red;
            slot2Color = GameColors.Colors.Blue;
        }
        else if (color == GameColors.Colors.Orange)
        {
            slot1Color = GameColors.Colors.Yellow;
            slot2Color = GameColors.Colors.Red;
        }
        else
        {
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
