using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sound;

namespace Stage {
    public class StageController : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefabRight;
        [SerializeField] private GameObject enemyPrefabLeft;
        [SerializeField] private GameObject bulletButtonLeft;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject missionText;
        
        private const int enemyCount = 150;
        private const float WaitTime = 2.0f;

        void Start()
        {

            SoundManager.Instance.PlayBGM(SoundManager.Bgm.Quest);

            // 初期は左射撃ボタンは非表示
            bulletButtonLeft.SetActive(false);

            // Enemyの量産
            StartCoroutine(CreateEnemyRight());
            StartCoroutine(CreateEnemyLeft());

            // ミッションテキスト非表示
            StartCoroutine(FadeMissionText());
        }

        private void Update()
        {
            // Playerが死亡した場合、ミッション失敗画面に遷移
            if (player == null)
            {
                // Enemyの量産はストップ
                StopCoroutine(CreateEnemyRight());
                StopCoroutine(CreateEnemyLeft());
                StartCoroutine(WaitLoad());
            }

        }

        /// <summary>
        /// 右から進行するEnemyの生成
        /// </summary>
        IEnumerator CreateEnemyRight()
        {
            // Enemy生成
            for (int countEnemyRight = enemyCount; 0 < countEnemyRight; countEnemyRight--)
            {
                yield return new WaitForSeconds(WaitTime);
                Instantiate(enemyPrefabRight);
            }
        }

        /// <summary>
        /// 左から進行するEnemyの生成
        /// </summary>
        IEnumerator CreateEnemyLeft()
        {
            // Enemy生成
            for (int countEnemyLeft = enemyCount; 0 < countEnemyLeft; countEnemyLeft--)
            {
                yield return new WaitForSeconds(WaitTime + 0.5f);
                Instantiate(enemyPrefabLeft);
            }
        }

        /// <summary>
        /// Player破壊後、2秒後にミッション失敗画面に遷移
        /// </summary>
        IEnumerator WaitLoad()
        {
            yield return new WaitForSeconds(WaitTime);
            SoundManager.Instance.StopBGM();
            SceneManager.LoadScene("Failed");
        }

        /// <summary>
        /// EXITボタン押下時
        /// </summary>
        public void OnReturnButton()
        {
            SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// ミッション用の指令テキストを非表示
        /// </summary>
        IEnumerator FadeMissionText()
        {
            yield return new WaitForSeconds(WaitTime * 2);
            missionText.SetActive(false);
        }

        /// <summary>
        /// タイマーがゼロになった場合、CompleteのScene呼び出し
        /// </summary>
        public static void OverTime(int seconds)
        {
            if (seconds <= 0)
            {
                SceneManager.LoadScene("Complete");
            }
        }
    }
}
