using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] public int playerLives = 3;

    [SerializeField] TextMeshProUGUI livesText;

    public AudioClip deathSound;
    private AudioSource audioSource;


    // Start is called before the first frame update

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void GameSessions()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        livesText.text = playerLives.ToString();
    }

    // Update is called once per frame
    public void ProcessPlayerDeath()
    {
        //audioSource.PlayOneShot(deathSound, .7f);

        Debug.Log(playerLives);
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        GameSessions();
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= 1 && currentSceneIndex <= 2)
        {
            SceneManager.LoadScene("FailGame");

        }

        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        GameSessions();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene("FailGame");
        Destroy(gameObject);
    }
}
