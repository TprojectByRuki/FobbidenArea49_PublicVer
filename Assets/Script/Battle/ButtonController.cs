using Sound;
using Player;
using UnityEngine;

namespace Button
{
    public class ButtonController : MonoBehaviour
    {

        [SerializeField] private GameObject player;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform bombPoint;
        [SerializeField] private GameObject bulletRightPrefab;
        [SerializeField] private GameObject bulletLeftPrefab;
        [SerializeField] private GameObject lefButton;
        [SerializeField] private GameObject rightButton;
        [SerializeField] private GameObject bulletButtonLeft;
        [SerializeField] private GameObject bulletButtonRight;
        [SerializeField] private GameObject jumpButton;
        [SerializeField] private GameObject bombButton;
        [SerializeField] private GameObject bombPrefab;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = player.GetComponent<PlayerController>();
        }

        /// <summary>
        /// 右移動ボタン押下
        /// </summary>
        public void OnPushDownRight()
        {
            _playerController.MoveRight();
        }

        /// <summary>
        /// 右移動ボタン離す
        /// </summary>
        public void OnPushUpRight()
        {
            _playerController.stopAnimation();
        }

        /// <summary>
        /// 左移動ボタン押下
        /// </summary>
        public void OnPushDownLeft()
        {
            _playerController.MoveLeft();
        }

        /// <summary>
        /// 左移動ボタン離す
        /// </summary>
        public void OnPushUpLeft()
        {
            _playerController.stopAnimation();
        }

        /// <summary>
        /// ジャンプボタン押下
        /// </summary>
        public void OnPushDownJump()
        {
            _playerController.Jump();
        }

        /// <summary>
        /// 右射撃ボタン押下
        /// </summary>
        public void OnPushShotBulletRight()
        {
            Instantiate(bulletRightPrefab, firePoint.position, transform.rotation);
            SoundManager.Instance.PlaySE(1);
        }

        /// <summary>
        /// 左射撃ボタン押下
        /// </summary>
        public void OnPushShotBulletLeft()
        {
            Instantiate(bulletLeftPrefab, firePoint.position, transform.rotation);
            SoundManager.Instance.PlaySE(1);
        }

        /// <summary>
        /// 爆弾投下ボタン押下
        /// </summary>
        public void OnPushDropBomb()
        {
            Instantiate(bombPrefab, bombPoint.position, Quaternion.Euler(0, 0, 180f));
            SoundManager.Instance.PlaySE(2);
            bombButton.SetActive(false);
        }

        /// <summary>
        /// ボタン無効化(Player死亡時)
        /// </summary>
        public void InvalidateButton()
        {
            lefButton.SetActive(false);
            rightButton.SetActive(false);
            bulletButtonLeft.SetActive(false);
            bulletButtonRight.SetActive(false);
            jumpButton.SetActive(false);
            bombButton.SetActive(false);
        }
    }
}
