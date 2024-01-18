using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 5f;
    public static bool gameOver = false;

    private void Start()
    {
        gameOver = false;    
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, -verticalInput, 0f);
        movement.Normalize(); 

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sun"))
        {
            print("GameOver! You hit the solar system");
            gameObject.SetActive(false);
            gameOver = true;
        }
    }
}
