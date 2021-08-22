using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacter : MonoBehaviour
    {
        private MBCharacterStateBase currentState;
        public Rigidbody2D rigidbody2D;

        [SerializeField]private int waitTimeJetpack;
        [SerializeField]private int jetpackDuration;
        [SerializeField]private int velocityMove;

        public int VelocityMove
        {
            get { return velocityMove; }
        }
        public int WaitTimeJetpack
        {
            get { return waitTimeJetpack; }
        }
        public int JetpackDuration
        {
            get { return jetpackDuration; }
        }

        public void SetState(MBCharacterStateBase state)
        {
            currentState = state;
        }

        private void Awake()
        {
            SetState(new MBCharacterStateDisabled(this));
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            currentState.UpdateState();

            //TODO: handle state input
            currentState.ProcessInput(MBInputManager.GetInstance().Direction,MBInputManager.GetInstance().SpecialPressedThisFrame);

            if(Input.GetKeyDown(KeyCode.T)){
                HandleLevelStageChanged(LevelStage.playing);
            }
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