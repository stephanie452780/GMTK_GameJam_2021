using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Animator animator;

    private float currentSpeed;

    void Start()
    {
        transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        currentSpeed = 0;
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.GetComponent<SpriteRenderer>().flipX = true;
            currentSpeed = speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.GetComponent<SpriteRenderer>().flipX = false;
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = 0;
        }
    }
}
