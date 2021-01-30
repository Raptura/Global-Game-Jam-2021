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
        fill.color = colorUI.activeColor;
    }

    void DropColor()
    {
        colorUI.updateColor(GameColors.noColor);
    }

    void SwapColorSlot()
    {
        colorUI.slot1Selected = !colorUI.slot1Selected;
    }
}
