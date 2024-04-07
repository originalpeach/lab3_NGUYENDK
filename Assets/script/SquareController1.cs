using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
 
    public float moveSpeed = 5f;


    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private Vector2 shootDirection;
    void Start()
    {
        StartCoroutine(Countdown());
        Debug.Log("xxx");

    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            //countdownText.text = "Time: " + timeRemaining.ToString();
        }
        
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

        // Bắn đạn khi người chơi nhấn Space
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
                // Nếu nhân vật chạm vào vùng màu đen, ngăn nhân vật di chuyển
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
        if (collision.gameObject.tag.Equals("Box"))
        {
            Debug.Log("hhhh");
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

        if (collision.CompareTag("MapEdge")) // Kiểm tra xem collider khác có phải là viền bản đồ không
        {
            Debug.Log("xxxxxx");
            // Dừng di chuyển của GameObject khi va chạm vào viền bản đồ
            Vector2 fistPosition = new Vector2(4, -4);
            transform.position = fistPosition;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * bulletSpeed;  // Bắn theo hướng "up" của GameObject
        }
    }
}
