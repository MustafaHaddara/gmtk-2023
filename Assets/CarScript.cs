using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICar : MonoBehaviour
{
    private ParticleSpawner myParticleSpawner;

    private Rigidbody2D myRigidBody;

    private Image myImage;
    private float collisionScale = 0.1f;

    private AudioSource myAudioSource;

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
    public bool isCollided = false;

    public GameObject slider;
    private bool showSlider = false;
    private Button myButton;
    private LogicScript logic;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        myParticleSpawner = gameObject.GetComponent<ParticleSpawner>();
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myImage = gameObject.GetComponentInChildren<Image>();
        myRigidBody = gameObject.GetComponentInChildren<Rigidbody2D>();
        myButton = gameObject.GetComponentInChildren<Button>();

        SetSpeed(0);
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (isCollided) {
            float velocityIncrement = myRigidBody.velocity.sqrMagnitude;
            float angleIncrement = myRigidBody.angularVelocity;
            int scoreIncrement = (int)((velocityIncrement + angleIncrement) / 100);
            if (scoreIncrement > 0)
            {
                logic.addScore(scoreIncrement);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Car") return;

        myRigidBody.velocity = myRigidBody.velocity * multiplier;
        myRigidBody.angularVelocity *= multiplier * 2;

        myRigidBody.drag = dragMultipler;
        myRigidBody.angularDrag = dragMultipler;

        isCollided = true;

        Vector3 squishVector = myRigidBody.velocity.normalized * collisionScale;

        gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x - squishVector.x,
            gameObject.transform.localScale.y - squishVector.y,
            gameObject.transform.localScale.z - squishVector.z
        );

        myImage.color = Color.black;
        myAudioSource.Play();

        myParticleSpawner.SpawnParticles();
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
