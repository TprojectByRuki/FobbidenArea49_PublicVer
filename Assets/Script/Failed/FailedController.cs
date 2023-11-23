using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sound;
using static Sound.SoundManager;

public class FailedController : MonoBehaviour
{
    [SerializeField] private GameObject loadingText;

    void Start()
    {
        SoundManager.Instance.PlayBGM(Bgm.Failed);
        loadingText.SetActive(false);
    }

    /// <summary>
    /// ボタン押下時(次ページロード)
    /// </summary>
    public void LoadTo(string sceneName)
    {
        SoundManager.Instance.PlaySE(0);
        loadingText.SetActive(true);

        // メニューに戻る場合、メニュー画面のBGMを鳴らす
        if (sceneName == "MainMenu")
        {
            SoundManager.Instance.PlayBGM(Bgm.MainMenu);
        }

        SceneManager.LoadScene(sceneName);
    }
}
