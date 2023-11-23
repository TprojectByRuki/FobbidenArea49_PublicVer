using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private int bulletDir;

    private const float BulletPos = 20f;
    private const float FieldOutPosRight = 12f;
    private const float FieldOutPosLeft = -12f;

    void Update()
    {
        // Bulletの移動
        transform.position += new Vector3(BulletPos * bulletDir, 0, 0) * Time.deltaTime;
        // 右に射撃したBulletの位置が定数(FieldOutPosRight)より大きい場合、
        // または左に射出したBulletの位置が定数(FieldOutPosLeft)より小さい場合
        if (transform.position.x > FieldOutPosRight || transform.position.x < FieldOutPosLeft)
        {
            // Bulletの破壊
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Enemyと衝突した場合
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemyと衝突したらBUlletを破壊
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
