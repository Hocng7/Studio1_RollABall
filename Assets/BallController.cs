using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float jumpSpeed = 35f;
    private bool isGrounded = true;

    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
    }

    // The jumping function
    public void Jump()
    {
        if (isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpSpeed,ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // function to detect collision with the ground 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
