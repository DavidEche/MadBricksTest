using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateGrounded : MBCharacterStateBase
    {
        private bool canUseJetPack = false;
        private float currentWaitTime;
        public MBCharacterStateGrounded(MBCharacter character) : base(character)
        {
            currentWaitTime = 0;
            canUseJetPack = false;
            character.rigidbody2D.gravityScale = 1;
        }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
            character.transform.position += new Vector3(direction.x,0,0) * Time.deltaTime *character.VelocityMove;
            if(specialPressed && canUseJetPack){
                character.SetState(new MBCharacterStateJetpack(character));
            }
        }

        public override void UpdateState()
        {
            if(!canUseJetPack){
               currentWaitTime += Time.deltaTime;
                Debug.Log((int)currentWaitTime);
               if(currentWaitTime >= character.WaitTimeJetpack){
                   canUseJetPack = true;
               }
            }
        }
    }
}