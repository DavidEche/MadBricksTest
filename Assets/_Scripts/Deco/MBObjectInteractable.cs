using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madbricks
{
public class MBObjectInteractable : MonoBehaviour
{
    [SerializeField] private EffectObjects effectObject;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<MBCharacter>().ObjectInteraction(effectObject);
            }
        }
    }

    public enum EffectObjects{
        Lose,
        Win
    }
}
