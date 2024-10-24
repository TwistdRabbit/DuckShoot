using UnityEngine;

public class BallHandling : MonoBehaviour
{
    
    private Material material;
    private Color[] colors = { Color.blue, Color.white, Color.yellow, Color.red };
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = colors[Random.Range(0, colors.Length)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }

    }
}
