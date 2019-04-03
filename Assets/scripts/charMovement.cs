using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour {

    // main menu canvas
    [SerializeField] private Canvas mainMenu;

    // gamecontroller gameobject
    [SerializeField] private GameObject controller;

    // set rigidbody
    private Rigidbody2D body;

    // base movement speed
    private const float baseSpeed = 6.0f;


    void Start() {

        // set rigidbody
        body = GetComponent<Rigidbody2D>();

        // cursor lock
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

    }

    void Update() {
        // set movement speed on input
        float movY = Input.GetAxis("Vertical") * baseSpeed;
        float movX = Input.GetAxis("Horizontal") * baseSpeed;

        //movement
        Vector2 velocity = new Vector2(movX, movY);
        body.MovePosition(new Vector2(transform.position.x, transform.position.y) + velocity * Time.fixedDeltaTime);

        // z position reset (might not be necessary for most setups, came from using 3d object in 2d space
        if (transform.position.z != 0) {
            Vector3 fixZ = transform.position;
            fixZ.z = 0;
            transform.position = fixZ;
        }
    }
}
