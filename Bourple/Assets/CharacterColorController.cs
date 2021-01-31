using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorController : MonoBehaviour
{
    private ColorUI colorUI;
    [SerializeField]
    private SpriteRenderer fill;

    private Input input;

    // Start is called before the first frame update
    void Start()
    {
        colorUI = FindObjectOfType<ColorUI>();
        input = new Input();
        input.Enable();

        input.Player.DropColor.performed += ctx => { DropColor(); };
        input.Player.SwapColor.performed += ctx => { SwapColorSlot(); };
    }

    // Update is called once per frame
    void Update()
    {
        fill.color = getColor(colorUI.activeColor);
    }

    void DropColor()
    {
        if (colorUI.slot1Selected && colorUI.slot1Color != GameColors.Colors.NoColor)
            AudioManager.instance.drop.PlayOneShot(AudioManager.instance.drop.clip);

        if (!colorUI.slot1Selected && colorUI.slot2Color != GameColors.Colors.NoColor)
            AudioManager.instance.drop.PlayOneShot(AudioManager.instance.drop.clip);

        colorUI.updateColor(GameColors.Colors.NoColor);

    }

    void SwapColorSlot()
    {
        colorUI.slot1Selected = !colorUI.slot1Selected;
        if (colorUI.slot1Selected)
            AudioManager.instance.swapA.PlayOneShot(AudioManager.instance.swapA.clip);
        else
            AudioManager.instance.swapB.PlayOneShot(AudioManager.instance.swapB.clip);

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
            case GameColors.Colors.NoColor:
            default:
                return GameColors.charNoColor;

        }
    }
}
