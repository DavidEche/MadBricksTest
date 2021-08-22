using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
    public class MBCharacterStateGrounded : MBCharacterStateBase
    {
        public MBCharacterStateGrounded(MBCharacter character) : base(character)
        { }

        public override void ProcessInput(Vector2 direction, bool specialPressed)
        {
            //TODO: Move Character right or left
            //TODO: if special ready and special pressed set character state to jetpack
        }

        public override void UpdateState()
        {
            //TODO: Charge Special
        }
    }
}