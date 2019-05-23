using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Utils;

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

    public void Cheer() {
        animator.SetBool(cheerAnimationKey, true);
        StartCoroutine(CheerCoroutine());
    }

    private IEnumerator RandomCheering() {
        while (true) {
            yield return new WaitForSeconds(cheerCooldownRange.GetRandom());
            Cheer();
        }
    }

    private IEnumerator CheerCoroutine() {
        yield return new WaitForSeconds(cheerTime);
        animator.SetBool(cheerAnimationKey, false);
    }

}