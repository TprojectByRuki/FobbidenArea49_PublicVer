using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sound;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text loadingText;

    /// <summary>
    /// ボタン押下時(次ページロード)
    /// </summary>
    public void LoadTo(string sceneName)
    {
        SoundManager.Instance.PlaySE(0);
        loadingText.text = "NOW LOADING...";
        SceneManager.LoadScene(sceneName);
    }
}
