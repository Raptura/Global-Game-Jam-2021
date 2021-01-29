using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterColorController : MonoBehaviour
{
    private ColorUI colorUI;
    private SpriteRenderer spriteRenderer;

    private Input input;

    // Start is called before the first frame update
    void Start()
    {
        colorUI = FindObjectOfType<ColorUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        input = new Input();
        input.Enable();

        input.Player.DropColor.performed += ctx => { DropColor(); };
        input.Player.SwapColor.performed += ctx => { SwapColorSlot(); };
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = colorUI.activeColor;
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
