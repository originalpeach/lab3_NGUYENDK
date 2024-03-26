using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public Text countdownText;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private Vector2 shootDirection;
    void Start()
    {
        StartCoroutine(Countdown());

    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shootDirection = Vector2.down;
        }

        // B?n ??n khi ng??i ch?i nh?n Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, 1.0f))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();

            if (renderer != null && renderer.material.color == Color.black)
            {
                // N?u nhân v?t ch?m vào vùng màu ?en, ng?n nhân v?t di chuy?n
                transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);
            }
        }


    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {

            Vector2 fistPosition = new Vector2(-8, 1);
            transform.position = fistPosition;

        }
        if (collision.gameObject.name.Equals("Box"))
        {

            LoadNextScene();

        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {

            Vector2 fistPosition = new Vector2(-9, 1);
            transform.position = fistPosition;

        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MapEdge")) // Ki?m tra xem collider khác có ph?i là vi?n b?n ?? không
        {
            Debug.Log("xxxxxx");
            // D?ng di chuy?n c?a GameObject khi va ch?m vào vi?n b?n ??
            Vector2 fistPosition = new Vector2(-9, 1);
            transform.position = fistPosition;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * bulletSpeed;  // B?n theo h??ng "up" c?a GameObject
        }
    }
}
