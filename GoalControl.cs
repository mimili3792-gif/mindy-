using UnityEngine;
using UnityEngine.SceneManagement; // 負責跳轉場景

public class GoalControl : MonoBehaviour
{
    [Header("場景設定")]
    public string winSceneName = "win"; // 過關場景的名字

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰到小貓咪的是不是玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("🐱 玩家救到小貓了！過關！");

            // 跳轉到過關場景
            SceneManager.LoadScene(winSceneName);
        }
    }
}