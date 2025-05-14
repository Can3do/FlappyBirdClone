using TMPro;
using UnityEngine;

public class ActualizarUI : MonoBehaviour
{

    TMP_Text ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ScoreText.SetText(GameManager.Instance.CurrentScore.ToString());
    }
}
