using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sound {
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField] private AudioSource audioSourceBGM;
        [SerializeField] private AudioSource audioSourceSE;
        [SerializeField] private AudioClip[] audioClipBGM;
        [SerializeField] private AudioClip[] audioClipSE;

        /// <summary>
        /// BGM用定数
        /// </summary>
        public enum Bgm
        {
            Title,
            MainMenu,
            Quest,
            Complete,
            Failed
        }

        /// <summary>
        /// 音素材の破棄制御
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                // オブジェクトを破棄しない
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                // オブジェクトの破棄
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// BGM実装
        /// </summary>
        public void PlayBGM(Bgm sceneName)
        {
            audioSourceBGM.Stop();

            switch (sceneName)
            {
                case Bgm.Title:
                    audioSourceBGM.clip = audioClipBGM[0];
                    break;
                case Bgm.MainMenu:
                    audioSourceBGM.clip = audioClipBGM[0];
                    break;
                case Bgm.Quest:
                    audioSourceBGM.clip = audioClipBGM[1];
                    break;
                case Bgm.Complete:
                    audioSourceBGM.clip = audioClipBGM[2];
                    break;
                case Bgm.Failed:
                    audioSourceBGM.clip = audioClipBGM[3];
                    break;
            }
            audioSourceBGM.Play();
        }

        /// <summary>
        /// BGMストップ
        /// </summary>
        public void StopBGM()
        {
            audioSourceBGM.Stop();
        }

        /// <summary>
        /// SE実装
        /// </summary>
        public void PlaySE(int index)
        {
            // 設定している引数よりも値が大きい場合
            if (audioClipSE.Length <= index)
            {
                throw new ArgumentException($"引数indexは{audioClipSE.Length}以上です。index:{index}");
            }
            audioSourceSE.PlayOneShot(audioClipSE[index]);
        }
    }
}

