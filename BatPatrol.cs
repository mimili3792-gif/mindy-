using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    [Header("移動設定")]
    public float speed = 2f;         // 移動速度
    public float patrolDistance = 3f; // 巡邏距離

    private Vector2 startPosition;    // 初始位置
    private bool movingRight = true;  // 當前移動方向

    void Start()
    {
        // 記錄起始位置
        startPosition = transform.position;
    }

    void Update()
    {
        // 計算這一幀要移動的量
        float movement = speed * Time.deltaTime;

        // 如果正在往右走
        if (movingRight)
        {
            transform.Translate(Vector2.right * movement);

            // 檢查是否超過巡邏範圍
            if (transform.position.x >= startPosition.x + patrolDistance)
            {
                movingRight = false; // 改向左走
                Flip();              // 翻轉圖片
            }
        }
        // 如果正在往左走
        else
        {
            transform.Translate(Vector2.left * movement);

            // 檢查是否超過巡邏範圍
            if (transform.position.x <= startPosition.x - patrolDistance)
            {
                movingRight = true;  // 改向右走
                Flip();              // 翻轉圖片
            }
        }
    }

    // 翻轉圖片，讓蝙蝠看起來面向移動方向
    void Flip()
    {
        // 取得當前的縮放比例 (Scale)
        Vector3 currentScale = transform.localScale;
        // 將 X 軸縮放乘以 -1 (水平翻轉)
        currentScale.x *= -1;
        // 套用新的縮放比例
        transform.localScale = currentScale;
    }
}