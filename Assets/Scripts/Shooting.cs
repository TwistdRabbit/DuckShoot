using UnityEngine;

public class Shooting : MonoBehaviour
{
    private RectTransform reticleTransform;
    public GameObject ballPrefab;
    public Transform shootOrigin;
    public float shootForce = 500f;
    public AudioSource audioSource;
    public AudioClip shootSound;
    void Start()
    {
        reticleTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 mouseposition = Input.mousePosition;
        reticleTransform.position = mouseposition;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, shootOrigin.position, Quaternion.identity);
        audioSource.PlayOneShot(shootSound);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction = (targetPosition - shootOrigin.position).normalized;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(direction * shootForce);
        }
    }
}
