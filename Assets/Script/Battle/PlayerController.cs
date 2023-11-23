using UnityEngine;
using Sound;
using Button;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private GameObject button;
        [SerializeField] private GameObject bulletButtonRight;
        [SerializeField] private GameObject bulletButtonLeft;
        [SerializeField] private GameObject explodePrefab;
        [SerializeField] private GameObject jumpButton;
        private Rigidbody2D _rigid2D;
        private Animator _animator;

        private const float WalkForce = 30.0f;
        private const float MaxWalkSpeed = 2.0f;
        private const float JumpUpLimit = 1.5f;
        private const float JumpForce = 350.0f;
        private const float PlayerScale = 0.4746f;
        private const float AdjustPlayerPositionX = 10f;
        private const float AdjustPlayerPositionY = 2.5f;
        private ButtonController buttonController;

        private void Awake()
        {
            buttonController = button.GetComponent<ButtonController>();
            _rigid2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.enabled = false;
        }

        void Update()
        {
            AdjustmentPositionIfNeeded();

            // ジャンプボタン表示・非表示制御(画面超えのジャンプ防止)
            if (transform.position.y >= JumpUpLimit)
            {
                // Playerが指定の高さを超えた場合、ジャンプボタンを非表示
                jumpButton.SetActive(false);
            }
            else if (transform.position.y <= JumpUpLimit)
            {
                // Playerが指定の高さに到達しない場合、ジャンプボタンを表示
                jumpButton.SetActive(true);
            }
        }

        /// <summary>
        /// 右へ移動
        /// </summary>
        public void MoveRight()
        {
            // 右向きに反転
            transform.localScale = new Vector3(PlayerScale, PlayerScale, PlayerScale);
            // ボタンの表示・非表示
            bulletButtonLeft.SetActive(false);
            bulletButtonRight.SetActive(true);

            // 歩くスピードの制御
            float speedx = Mathf.Abs(_rigid2D.velocity.x);

            if (speedx < MaxWalkSpeed)
            {
                _rigid2D.AddForce(transform.right * 1 * WalkForce);
            }

            // アニメーション開始
            _animator.enabled = true;
            _animator.speed = speedx / 2.0f;

        }

        /// <summary>
        /// 左へ移動
        /// </summary>
        public void MoveLeft()
        {
            // 左向きに反転
            transform.localScale = new Vector3(PlayerScale * -1, PlayerScale, PlayerScale);
            // ボタンの表示・非表示
            bulletButtonRight.SetActive(false);
            bulletButtonLeft.SetActive(true);

            // 歩くスピードの制御
            float speedx = Mathf.Abs(_rigid2D.velocity.x);

            if (speedx < MaxWalkSpeed)
            {
                _rigid2D.AddForce(transform.right * -1 * WalkForce);
            }

            // アニメーション開始
            _animator.enabled = true;
            _animator.speed = speedx / 2.0f;
        }

        /// <summary>
        /// ジャンプ
        /// </summary>
        public void Jump()
        {
            _rigid2D.AddForce(transform.up * JumpForce);
        }

        /// <summary>
        /// アニメーションストップ
        /// </summary>
        public void stopAnimation()
        {
            _animator.enabled = false;
        }

        /// <summary>
        /// 移動範囲の制限
        /// </summary>
        void AdjustmentPositionIfNeeded()
        {
            var playerPosition = transform.position;

            playerPosition.x = Mathf.Clamp(playerPosition.x, AdjustPlayerPositionX * -1, AdjustPlayerPositionX);
            playerPosition.y = Mathf.Clamp(playerPosition.y, AdjustPlayerPositionY * -1, AdjustPlayerPositionY * 2);

            transform.position = playerPosition;
        }

        /// <summary>
        /// Playerの破壊 ※isTrigger(Bullet)
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // ボタン類は非表示に変更
                buttonController.InvalidateButton();

                // 爆発エフェクト生成
                Instantiate(explodePrefab, transform.position, transform.rotation);

                // Playerの破壊
                Destroy(gameObject);
                SoundManager.Instance.PlaySE(3);
            }
        }
    }
}
