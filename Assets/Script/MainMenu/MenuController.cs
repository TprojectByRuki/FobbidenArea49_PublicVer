using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sound;
using static Sound.SoundManager;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text loadingText;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(Bgm.MainMenu);
    }

    /// <summary>
    /// ボタン押下時(次ページロード)
    /// </summary>
    public void LoadTo(string sceneName)
    {
        SoundManager.Instance.PlaySE(0);
        loadingText.text = "NOW LOADING...";
        SoundManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneName);
    }
}
