using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoCrashesLogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text targetText;
    public GameObject nextLevelButton;

    private bool isStarted = false;
    private List<UICar> cars;
    private int numSafeCars;

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Car")
            .ToList()
            .ConvertAll<UICar>(gameObject => gameObject.GetComponent<UICar>());

        targetText.text = $"target: 0";
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
    }

    public void carIsSafe() {
        numSafeCars += 1;

        if (numSafeCars >= cars.Count) {
            nextLevelButton.SetActive(true);
        }
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
