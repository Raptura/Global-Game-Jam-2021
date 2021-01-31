using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    private ColorUI colorUI;
    public GameColors.Colors goal;
    private SpriteRenderer sr;
    private ColorPip pip;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        colorUI = FindObjectOfType<ColorUI>();
        pip = transform.GetChild(0).GetComponent<ColorPip>();
        pip.color = goal;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (colorUI.activeColor == goal)
            {
                FinishLevel();
            }
        }
    }

    void FinishLevel()
    {
        anim.Play("Goal_Happy");
        sr.color = getColor(goal);
        colorUI.clearColor();
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
