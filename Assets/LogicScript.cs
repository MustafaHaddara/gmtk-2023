using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text targetText;
    public int scoreToAdvance;
    public GameObject nextLevelButton;

    private bool isStarted = false;
    private List<UICar> cars;

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Car")
            .ToList()
            .ConvertAll<UICar>(gameObject => gameObject.GetComponent<UICar>());

        targetText.text = $"target: {scoreToAdvance}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart() {
        if (isStarted) return;

        isStarted = true;

        cars.ForEach(car => car.OnStart());
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > scoreToAdvance) {
            nextLevelButton.SetActive(true);
        }
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
