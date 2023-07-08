using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICar : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    public Vector2 initialDirection;

    public float multiplier;
    public float dragMultipler;

//
    public int minSpeed;
    public int maxSpeed;

    public int minDisplaySpeed = 20;
    public int maxDisplaySpeed = 200;

    public Text speedDisplay;

    private int speed;
    private bool isCollided = false;

    public GameObject slider;
    private bool showSlider = false;
    private Button myButton;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myButton = gameObject.GetComponent<Button>();
        Debug.Log(myRigidBody);

        SetSpeed(0);
    }

    // Update is called once per frame
    void Update() {

        if (isCollided) {
            float velocityIncrement = myRigidBody.velocity.sqrMagnitude;
            float angleIncrement = myRigidBody.angularVelocity;
            int scoreIncrement = (int)((velocityIncrement + angleIncrement) / 10000);
            logic.addScore(scoreIncrement);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        myRigidBody.velocity = myRigidBody.velocity * multiplier;
        myRigidBody.angularVelocity *= multiplier * 2;

        myRigidBody.drag = dragMultipler;
        myRigidBody.angularDrag = dragMultipler;

        isCollided = true;
    }

    public void OnStart() {
        myButton.enabled = false;
        SetSlider(false);
        myRigidBody.velocity = initialDirection * speed;
    }

    public void OnClick()
    {
        SetSlider(!showSlider);
    }

    private void SetSlider(bool state) {
        showSlider = state;
        slider.SetActive(state);
    }

    public void SetSpeed(float value) {
        speed = (int) Mathf.Lerp(minSpeed, maxSpeed, value);
        speedDisplay.text = ((int) Mathf.Lerp(minDisplaySpeed, maxDisplaySpeed, value)).ToString();
    }
}
