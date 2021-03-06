using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBLevelManager : MonoBehaviour
    {

        private static MBLevelManager _instance;

        public static MBLevelManager GetInstance(){
            if(_instance == null){
                var newGameObject = new GameObject();
                newGameObject.name = "MBLevelManager";
                _instance = newGameObject.AddComponent<MBLevelManager>();
            }
            return _instance;
        }

        public event System.Action<LevelStage> OnLevelStateChanged;

        public LevelStage LevelStage { get; private set; } = LevelStage.setup;

        public void StartGame()
        {
            SetLevelState(LevelStage.playing);
        }

        public void RestartGame(){
            SetLevelState(LevelStage.setup);
        }

        public void Win()
        {
            if (LevelStage != LevelStage.playing) { return; }
            SetLevelState(LevelStage.win);
        }

        public void Lose()
        {
            if (LevelStage != LevelStage.playing) { return; }
            SetLevelState(LevelStage.lose);
        }

        private void SetLevelState(LevelStage state)
        {
            LevelStage = state;
            OnLevelStateChanged?.Invoke(LevelStage);
        }
    }

    public enum LevelStage
    {
        setup = 0,
        playing = 1,
        win = 2,
        lose = 3
    }
}