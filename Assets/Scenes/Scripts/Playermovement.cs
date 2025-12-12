
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMove, 0f, verticalMove);
        float magnitude = Mathf.Clamp01(moveDirection.magnitude);
        Vector3 move = moveDirection.normalized;

        if (controller.isGrounded)
        {
            if (ySpeed < 0f) ySpeed = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(jumpSpeed * -2f * Physics.gravity.y);
            }
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = move * speed * magnitude;
        velocity.y = ySpeed;
        controller.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            GameManager.health -= 1;
        }
    }
}
