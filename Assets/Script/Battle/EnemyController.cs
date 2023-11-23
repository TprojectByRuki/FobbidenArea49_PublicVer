using UnityEngine;
using Sound;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] private GameObject explodePrefab;
    private int _moveDirection = 1;
    private Vector3 _enemyPosition;

    private const float EnemyMoveLimitedLeft = 13.0f;
    private const float EnemyMoveLimitedRight = -11.0f;
    private const float Position = 0.2331f;
    private const float Position2 = -0.2331f;

    private void Update()
    {

        Moving();

    }

    /// <summary>
    /// Enemyの移動
    /// </summary>
    void Moving()
    {

        // 自動移動
        _enemyPosition = transform.position;

        // 動く方向でEnemy移動
        transform.Translate(transform.right * Time.deltaTime * 2.5f * _moveDirection);

        if (_enemyPosition.x > EnemyMoveLimitedLeft)
        {
            _moveDirection = -1;
            // 動く方向でEnemy反転
            transform.localScale = new Vector3(Position, Position, Position);
        }

        if (_enemyPosition.x < EnemyMoveLimitedRight)
        {
            _moveDirection = 1;
            // 動く方向でEnemy反転
            transform.localScale = new Vector3(Position2, Position, Position);
        }
    }

    /// <summary>
    /// Enemyの破壊
    /// ※BulletにisTriggerのチェックをつけた場合に呼ばれる
    /// </summary>　
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // 爆発エフェクト生成
            Instantiate(explodePrefab, transform.position, transform.rotation);

            // Enemyの破壊
            Destroy(gameObject);
            SoundManager.Instance.PlaySE(3);
        }
        else if (collision.CompareTag("Bomb"))
        {
            // 爆発エフェクト生成
            Instantiate(explodePrefab, transform.position, transform.rotation);

            // Enemyの破壊
            Destroy(gameObject);
            SoundManager.Instance.PlaySE(4);
        }
    }
}
