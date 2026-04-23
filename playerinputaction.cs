using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerinputaction : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;

    [Header("場景設定")]
    [SerializeField] private string loseSceneName = "LoseScene";

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource; // 新增音訊變數
    private Vector2 moveInput;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // 取得 AudioSource

        if (rb == null) Debug.LogError("找不到 Rigidbody2D！");
        if (anim == null) Debug.LogWarning("找不到 Animator！");
        if (audioSource == null) Debug.LogWarning("主角身上沒掛 AudioSource，將無法播放音效！");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            moveInput = Vector2.zero;
            return;
        }
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isDead && context.started)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("跳躍成功！");
        }
    }

    void FixedUpdate()
    {
        // 如果受傷了，就不要再更新速度和動畫參數，避免覆蓋受傷動作
        if (rb == null || isDead) return;

        float targetXVelocity = moveInput.x * moveSpeed;
        rb.linearVelocity = new Vector2(targetXVelocity, rb.linearVelocity.y);

        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput.x));
        }

        if (moveInput.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDead)
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        isDead = true;
        Debug.Log("玩家受傷了！播放音效與動畫");

        // 1. 播放音效
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // 2. 播放受傷動畫 (直接強制播放動畫狀態名稱，確保 100% 成功)
        if (anim != null)
        {
            anim.Play("Player_Hurt", 0, 0f);
        }

        // 3. 停止物理移動，避免滑行
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false; // 選用：讓主角不再受物理影響（防止死後又撞到東西）

        // 4. 等待 1.5 秒，讓玩家看清楚受傷動作並聽完聲音
        yield return new WaitForSeconds(3.0f);

        // 5. 切換場景
        SceneManager.LoadScene(loseSceneName);
    }
}