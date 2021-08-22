using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateJetpack : MBCharacterStateBase
    {
        private float currentWaitTime;
        public MBCharacterStateJetpack(MBCharacter character) : base(character)
        {
            character.rigidbody2D.gravityScale = 0f;
        }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
            character.transform.position += new Vector3(direction.x,direction.y,0) * Time.deltaTime *character.VelocityMove;
        }

        public override void UpdateState()
        {
            currentWaitTime += Time.deltaTime;
            if(currentWaitTime >= character.JetpackDuration){
                character.SetState(new MBCharacterStateGrounded(character));
            }
        }
    }
}
