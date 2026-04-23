using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查是不是撞到玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家碰到敵人，失敗！");

            // 跳轉到你的「失敗場景」
            // 請確保你的失敗場景名稱跟下面括號內一模一樣
            SceneManager.LoadScene("lose");
        }
    }
}