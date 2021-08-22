using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacter : MonoBehaviour
    {
        private MBCharacterStateBase currentState;

        public void SetState(MBCharacterStateBase state)
        {
            currentState = state;
        }

        private void Awake()
        {
            SetState(new MBCharacterStateDisabled(this));
        }

        private void Update()
        {
            currentState.UpdateState();

            //TODO: handle state input
            Debug.Log(MBInputManager.GetInstance().Direction);
        }

        private void HandleLevelStageChanged(LevelStage stage)
        {
            if (stage == LevelStage.playing)
            {
                SetState(new MBCharacterStateGrounded(this));
            }
        }
    }
}