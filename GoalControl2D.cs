using UnityEngine;
using UnityEngine.SceneManagement; // 負責切換場景

public class GoalControl2D : MonoBehaviour
{
    [Header("設定")]
    public string nextSceneName = "NEW S"; // 下一個場景的名字
    public float delayTime = 2.0f;           // 延遲幾秒後跳轉

    // 注意：2D 必須使用 OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰到的物件是不是玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("2D 玩家已抵達終點！");

            // 呼叫跳轉功能
            Invoke("LoadNextScene", delayTime);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}