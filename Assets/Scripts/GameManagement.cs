using System.Threading;
using TMPro;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public int score;
    public float timer;
    public AudioSource audioSource;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    //menu
    public AudioClip duckClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
        timer = 200;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        scoreText.text = score.ToString();

        if (timer <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void ScoreUpdate()
    {
        score++;
        audioSource.PlayOneShot(duckClip);
    }
}
