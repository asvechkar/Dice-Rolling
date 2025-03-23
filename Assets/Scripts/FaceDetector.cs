using System;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
        [SerializeField]
        private DiceRoll dice;

        private void OnTriggerStay(Collider other)
        {
                if (dice.GetComponent<Rigidbody>().linearVelocity == Vector3.zero)
                {
                        dice.diceFaceNum = int.Parse(other.name);
                }
        }
}