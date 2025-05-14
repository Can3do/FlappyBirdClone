using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CurrentScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Asegura que solo haya una instancia del ScoreManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persiste entre escenas si es necesario
    }

    public void AddPoints(int amount)
    {
        CurrentScore += amount;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
