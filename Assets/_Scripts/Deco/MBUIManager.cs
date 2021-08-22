using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBUIManager : MonoBehaviour
    {
        [SerializeField]private MBLevelManager mBLevelManager;
        [SerializeField]private GameObject winView;
        [SerializeField]private GameObject loseView;
        [SerializeField]private GameObject SetupView;

        private void Start() {
            mBLevelManager = MBLevelManager.GetInstance();
            mBLevelManager.OnLevelStateChanged += LevelStateChanged;
            LevelStateChanged(LevelStage.setup);
        }

        public void StartButtonTest(){
            mBLevelManager.StartGame();
        }

        private void LevelStateChanged(LevelStage levelStage){
            switch (levelStage)
            {
                case LevelStage.setup:
                    SetupView.SetActive(true);
                    winView.SetActive(false);
                    loseView.SetActive(false);
                    break;
                case LevelStage.playing:
                    SetupView.SetActive(false);
                    break;
                case LevelStage.win:
                    winView.SetActive(true);
                    break;
                case LevelStage.lose:
                    loseView.SetActive(true);
                    break;
            }
        }
    }
}
