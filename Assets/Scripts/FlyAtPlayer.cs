using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float projectileSpeed = 10f;
    Vector3 playerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, projectileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
