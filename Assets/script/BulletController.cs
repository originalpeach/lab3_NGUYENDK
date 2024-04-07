using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int scoreValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {

            ScoreManager.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MapEdge")) // Kiểm tra xem collider khác có phải là viền bản đồ không
        {
            Destroy(gameObject);
        }
    }
}