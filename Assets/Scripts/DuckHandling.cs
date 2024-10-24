using System.Collections;
using UnityEngine;

public class DuckHandling : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 moveDirection;
    public GameManagement gameManagement;

    void Start()
    {
        gameManagement = GameObject.FindWithTag("MainCamera").GetComponent<GameManagement>();

        if (transform.position.x < 0)
        {
            moveDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(-90, 90, 0);
        }
        else
        {
            moveDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(-90, -90, 0);
        }
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameManagement.ScoreUpdate();
            Invoke("Destroy", 0.1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
