using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour

{
    public Rigidbody2D myRigidBody;

    public float initialSpeed;
    public Vector2 initialDirection;

    public float multiplier;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = initialDirection * initialSpeed;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnCollisionEnter2D(Collision2D collision) {
        myRigidBody.velocity = myRigidBody.velocity * multiplier;
        myRigidBody.angularVelocity *= multiplier;
        int scoreIncrement =  (int)(1000*(myRigidBody.velocity.x + myRigidBody.velocity.y));
        logic.addScore(scoreIncrement);
        // Vector2 direction = new Vector2(
        //     -1 * Mathf.Sign(initialDirection.x) * Random.value,
        //     Random.value
        // );
        // direction = direction / direction.magnitude;

        // myRigidBody.velocity = direction * Random.Range(minMultiplier, maxMultiplier);

        // myRigidBody.angularVelocity = Random.value * 360;
    }
}
