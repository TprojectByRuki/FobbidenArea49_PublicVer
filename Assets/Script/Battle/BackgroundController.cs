using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private const float Position = -8.0f;

    private void Update()
    {
        // 背景の移動
        transform.Translate(-0.01f, 0, 0);

        if (transform.position.x < Position)
        {
            // 初期位置に戻る
            transform.position = Vector3.zero;
        }
    }
}
