using UnityEngine;
using UnityEngine.SceneManagement; // 必須引用，才能控制場景跳轉

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 60f; // 設定總時間 60 秒
    private float timer;

    void Start()
    {
        timer = timeLimit; // 初始化計時器
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // 每一幀減去流逝的時間

            // (選擇性) 如果你有 UI 文字，可以在這裡顯示 timer
            // Debug.Log("剩餘時間: " + (int)timer); 
        }
        else
        {
            // 時間到了！
            Debug.Log("60秒時間結束，跳轉場景！");
            SceneManager.LoadScene("lose"); // 請確保括號內是你的失敗場景名稱
        }
    }
}