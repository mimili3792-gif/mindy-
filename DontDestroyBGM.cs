using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    private static DontDestroyBGM instance;

    void Awake()
    {
        // 檢查是否已經有音樂物件在場景中
        if (instance == null)
        {
            instance = this;
            // 讓這個物件在切換場景時不會被刪除
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果已經有了，就刪除重複的自己
            Destroy(gameObject);
        }
    }
}