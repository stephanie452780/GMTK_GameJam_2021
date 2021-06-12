using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool flipLeft = false;

    void Start()
    {
        transform.position = new Vector3(-4, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
