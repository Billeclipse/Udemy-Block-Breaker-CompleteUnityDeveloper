using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public bool autoPlay = false;

    private Paddle paddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        paddle.setAutoPlay(autoPlay);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoPlay = !autoPlay;
            paddle.setAutoPlay(autoPlay);
        }
    }
}
