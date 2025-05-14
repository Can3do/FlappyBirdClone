using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    public float MovementSpeed = 1.5f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.linearVelocity = new Vector3(MovementSpeed * -1f, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {

        // transform.position = new Vector3(transform.position.x - MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
