using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Utils;

namespace PeppaSquad.Pickups.Animations {
    /// <summary>
    /// Handles the WW's cheer animations
    /// </summary>
    public class PickupCheerAnimationHandler : MonoBehaviour {

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private float cheerTime = 4f;

        [SerializeField]
        private NumberRange cheerCooldownRange;

        private const string cheerAnimationKey = "IsCheering";

        private Coroutine randomCheerRoutine;

        private void Awake() {
            randomCheerRoutine = StartCoroutine(RandomCheering());
        }

        /// <summary>
        /// Starts the WW cheer animation
        /// </summary>
        public void Cheer() {
            animator.SetBool(cheerAnimationKey, true);
            StartCoroutine(CheerCoroutine());
        }

        /// <summary>
        /// Makes the WW cheer after random amounts of time
        /// </summary>
        /// <returns></returns>
        private IEnumerator RandomCheering() {
            while (true) {
                yield return new WaitForSeconds(cheerCooldownRange.GetRandom());
                Cheer();
            }
        }

        /// <summary>
        /// Stops the cheereing animation after a certain amount of time.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheerCoroutine() {
            yield return new WaitForSeconds(cheerTime);
            animator.SetBool(cheerAnimationKey, false);
        }

    }
}