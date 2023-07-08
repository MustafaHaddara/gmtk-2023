using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isStarted = false;
    private List<UICar> cars;

    // Start is called before the first frame update
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Car")
            .ToList()
            .ConvertAll<UICar>(gameObject => gameObject.GetComponent<UICar>());

        Debug.Log(cars.Count);
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
}
