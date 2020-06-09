﻿namespace UniGame.Routines.Runtime.Extension
{
    using System.Collections;
    using UniGreenModules.UniRoutine.Runtime.Extension;
    using UnityEngine;

    public static class AnimatorExtensions
    {
        public static IEnumerator WaitForEnd(this Animator animator, int stateHash, int layer = 0)
        {
            while (animator.GetCurrentAnimatorStateInfo(layer).shortNameHash != stateHash) {
                yield return null;
            }

            yield return animator.WaitForSeconds(animator.GetCurrentAnimatorStateInfo(layer).length);
        }
    }
}