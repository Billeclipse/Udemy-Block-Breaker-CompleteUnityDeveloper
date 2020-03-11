using UnityEngine;
using TMPro;
using System.Collections;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public bool autoPlay = false;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] public TextMeshProUGUI scoreText;
    
    private Paddle paddle;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        if (paddle != null)
        {
            paddle.setAutoPlay(autoPlay);
        }

        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

        paddle = FindObjectOfType<Paddle>();
        if (paddle != null)
        {
            paddle.setAutoPlay(autoPlay);
        }        
                
        if (Input.GetKeyDown(KeyCode.A))
        {            
            autoPlay = !autoPlay;
        }
    }
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
