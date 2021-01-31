using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPost : MonoBehaviour
{
    private ColorUI colorUI;
    [SerializeField]
    private GameColors.Colors goal;
    [SerializeField]
    private string nextLevel;
    private SpriteRenderer sr;
    private ColorPip pip;
    [SerializeField]
    private ColorPip ui_pip;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        colorUI = FindObjectOfType<ColorUI>();
        pip = transform.GetChild(0).GetComponent<ColorPip>();
        pip.color = goal;
        ui_pip = GameObject.Find("UI_Pip").GetComponent<ColorPip>();
        ui_pip.color = goal;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (colorUI.activeColor == goal)
            {
                FinishLevel();
                Invoke("GoToNextLevel", 3);
            }
        }
    }

    void FinishLevel()
    {
        anim.Play("Goal_Happy");
        sr.color = getColor(goal);
        colorUI.clearColor();
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
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
