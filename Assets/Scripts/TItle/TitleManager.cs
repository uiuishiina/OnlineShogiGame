using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace KTC.Title
{
    public class TitleManager : MonoBehaviour
    {

        /* == 外部参照変数 == */

        [Header("StartPanel参照")]
        [SerializeField] GameObject _startPanel = null;

        [SerializeField] Button     _startButton = null;
        [SerializeField] Button     _settingButton = null;
        [SerializeField] Button     _quitButton = null;
        [SerializeField] Image      _startBGImage = null;
        [SerializeField] GameObject _startPanelItems = null;

        const float MAX_START_SEQUENCE_INTERVAL = 5.0f;
        [SerializeField, Range(0f, MAX_START_SEQUENCE_INTERVAL)] float _startSequenceInterval = 0.0f;

        [Header("SettingPanel参照")]
        [SerializeField] GameObject _settingPanel = null;

        [SerializeField] Button     _closeSettingButton = null;
        [SerializeField] Image      _settingImage = null;
        [SerializeField] GameObject _settingPanelItems = null;

        [Header("QuitPanel参照")]
        [SerializeField] GameObject _quitPanel = null;

        [SerializeField] Button     _yesButton = null;
        [SerializeField] Button     _noButton = null;
        [SerializeField] Image      _quitImage = null;

        [SerializeField] GameObject _quitPanelItems = null;

        /* == 内部変数 == */

        private void Start()
        {
            InitPanelSetting();
            InitButtonSetting();
        }

        /// <summary>
        /// ボタン設定初期化
        /// </summary>
        void InitButtonSetting()
        {
            //  Start
            _startButton.onClick.AddListener(() => { Debug.Log("GameStart"); });
            
            _settingButton.onClick.AddListener(() => { 

                _settingPanel.SetActive(true);
                TweenerCore<Vector3, Vector3, VectorOptions> tween = TitleUIAnimation.ExpansionRectX(
                   _settingImage.rectTransform,
                   () =>{ _settingPanelItems.SetActive(true); }
                   );
                tween.Play();
            });

            _quitButton.onClick.AddListener(() => { 

                _quitPanel.SetActive(true);
                TweenerCore<Vector3, Vector3, VectorOptions> tween = TitleUIAnimation.ExpansionRectY(
                    _quitImage.rectTransform,
                    () => { _quitPanelItems.SetActive(true); }
                    );
                tween.Play();
            });

            //  Setting
            _closeSettingButton.onClick.AddListener(() => {

                _settingPanelItems.SetActive(false);
                TweenerCore<Vector3, Vector3, VectorOptions> tween = TitleUIAnimation.ExpansionRectX(
                    _settingImage.rectTransform,
                    () => { _settingPanel.SetActive(false); },
                    0
                    );
                tween.Play();
            });

            //  Quit
            _yesButton.onClick.AddListener(() => {

                /*ゲーム終了処理*/
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif

            });
            _noButton.onClick.AddListener(() => {
                
                _quitPanelItems.SetActive(false);
                TweenerCore<Vector3, Vector3, VectorOptions> tween = TitleUIAnimation.ExpansionRectY(
                    _quitImage.rectTransform,
                    () =>{ _quitPanel.SetActive(false); },
                    0
                    );
                tween.Play();
            });
        }

        /// <summary>
        /// Panel設定初期化
        /// </summary>
        void InitPanelSetting()
        {
            _startPanel.SetActive(true);
            _startPanelItems.SetActive(false);

            Sequence startSequence = DOTween.Sequence();
            startSequence.AppendInterval(_startSequenceInterval);
            startSequence.Append(
                TitleUIAnimation.ExpansionRectX(
                   _startBGImage.rectTransform,
                   () => { _startPanelItems.SetActive(true); }
                   )
                );
            startSequence.Play();


            _settingPanel.SetActive(false);
            _settingPanelItems.SetActive(false);

            _quitPanel.SetActive(false);
            _quitPanelItems.SetActive(false);
        }
    }
}