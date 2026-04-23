using UnityEngine;
using UnityEngine.SceneManagement; // 負責切換場景

public class GameControl : MonoBehaviour
{
    [Header("UI 面板設定")]
    public GameObject instructionPanel;

    [Header("場景設定")]
    public string gameSceneName = "GameScene";
    public string mainMenuName = "MainMenu"; // 新增：主選單的場景名稱

    // 1. 開始遊戲 / 重新挑戰
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
        Time.timeScale = 1f;
        Debug.Log("載入遊戲中...");
    }

    // 2. 回到主選單 (這是你剛才找不到的功能)
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1f;
        Debug.Log("回到主選單...");
    }

    // 3. 開啟玩法說明
    public void OpenInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
    }

    // 4. 關閉玩法說明
    public void CloseInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }
    }

    // 5. 退出遊戲
    public void QuitGame()
    {
        Debug.Log("點擊了退出遊戲");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}