using UnityEngine;

public class Mover : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    bool IsOnGround = false;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody>();
        PrintInstructions();
    }

    private void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag == "Ground") {
        IsOnGround = true;
        Debug.Log("On Ground");
    }
}

    private void OnCollisionStay(Collision other) {
    if (other.gameObject.tag == "Ground") {
        IsOnGround = true;
        Debug.Log("On Ground");
    }
    }

private void OnCollisionExit(Collision other) {
    if (other.gameObject.tag == "Ground") {
        IsOnGround = false;
        Debug.Log("Not On Ground");
    }
}
    // Update is called once per frame
    void Update() {
        MovePlayer();
        // OnCollision should not be called here
    }

    void PrintInstructions() {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer() {
        // Move the player based on input
        float xValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // Sprint when Fire1 is pressed
        if (Input.GetAxis("Fire1") > 0) {
            moveSpeed = 16f;
        } else {
            moveSpeed = 10f;
        }

        // Jump if the player is on the ground
        if (IsOnGround && Input.GetKeyDown(KeyCode.Space)) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        transform.Translate(xValue, yValue, zValue);
    }

}