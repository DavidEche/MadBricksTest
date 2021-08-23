using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacter : MonoBehaviour
    {
        private MBCharacterStateBase currentState;
        private MBLevelManager mBLevelManager;
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
            mBLevelManager = MBLevelManager.GetInstance();
            mBLevelManager.OnLevelStateChanged += HandleLevelStageChanged;
        }

        private void Update()
        {
            currentState.UpdateState();

            currentState.ProcessInput(MBInputManager.GetInstance().Direction,MBInputManager.GetInstance().SpecialPressedThisFrame);
        }

        private void HandleLevelStageChanged(LevelStage stage)
        {
            switch (stage)
            {
                case LevelStage.setup:
                    transform.position = Vector3.zero;
                    break;
                case LevelStage.playing:
                    SetState(new MBCharacterStateGrounded(this));
                    break;
                case LevelStage.win:
                    SetState(new MBCharacterStateDisabled(this));
                    break;
                case LevelStage.lose:
                    SetState(new MBCharacterStateDisabled(this));
                    break;
            }
        }
        public void ObjectInteraction(EffectObjects effect){
            switch (effect)
            {
                case EffectObjects.Win:
                    mBLevelManager.Win();
                    break;
                case EffectObjects.Lose:
                    mBLevelManager.Lose();
                    break;
            }
            
        }
    }
}