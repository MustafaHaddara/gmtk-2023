using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] steps;
    private int nextStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteStep(int step) {
        if (nextStep == step) {
            nextStep = step + 1;

            steps[step].SetActive(false);

            if (step+1 < steps.Length) {
                steps[step+1].SetActive(true);
            }
        }
    }
}
