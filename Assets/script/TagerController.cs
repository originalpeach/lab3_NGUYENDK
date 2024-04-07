using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Tăng điểm số khi viên đạn va chạm vào mục tiêu
            ScoreManager.Instance.IncreaseScore(scoreValue);

            // Biến mục tiêu và viên đạn biến mất
            Destroy(gameObject); // Mục tiêu
            Destroy(collision.gameObject); // Viên đạn
        }
    }
}
