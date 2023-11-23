using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Stage;
using static Stage.StageController;

public class TimeCountController : MonoBehaviour
{

    [SerializeField] private Text timerText;
    [SerializeField] private float totalTime;
    private int _seconds;

    void Update()
    {
        // タイマーのカウント制御
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            _seconds = (int)totalTime;
            timerText.text = $"{_seconds}min";
        }

        // タイマーがゼロになった場合
        StageController.OverTime(_seconds);
    }
}

