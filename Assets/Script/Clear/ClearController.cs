using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sound;
using static Sound.SoundManager;

public class ClearController : MonoBehaviour
{
    [SerializeField] private GameObject loadingText;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(Bgm.Complete);
        loadingText.SetActive(false);
    }

    /// <summary>
    /// ボタン押下時(次ページロード)
    /// </summary>
    public void LoadTo(string sceneName)
    {
        SoundManager.Instance.PlaySE(0);
        loadingText.SetActive(true);
        SoundManager.Instance.PlayBGM(Bgm.MainMenu);
        SceneManager.LoadScene(sceneName);
    }
}
