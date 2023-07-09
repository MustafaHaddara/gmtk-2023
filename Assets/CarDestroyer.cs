using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
    private NoCrashesLogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<NoCrashesLogicScript>();
    }

    void OnTriggerExit2D(Collider2D collider) {
        UICar car = collider.gameObject.GetComponentInParent<UICar>();
        if (car != null && !car.isCollided) {
            Destroy(car.gameObject);
            logic.carIsSafe();
        }
    }
}
