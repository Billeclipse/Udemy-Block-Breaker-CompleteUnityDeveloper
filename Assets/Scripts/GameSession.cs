using UnityEngine;
using TMPro;
using System.Collections;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public bool autoPlay = false;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] public TextMeshProUGUI scoreText;
    
    private Paddle paddle;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
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
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {            
        if (Input.GetKeyDown(KeyCode.A))
        {            
            autoPlay = !autoPlay;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(gameSpeed >= 0.1f)
            {
                gameSpeed -= 0.5f;
            }
            
        }else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameSpeed <= 10f)
            {
                gameSpeed += 0.5f;
            }
        }

        Time.timeScale = gameSpeed;
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

    public bool getAutoPlay()
    {
        return autoPlay;
    }
}
