using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hammond/CheckIfAnimationFinishedDecision")]
    public class H_CheckAnimationFinishedDecision : Decision<Hammond> {
        public override bool Decide(Hammond type) => type.isAnimationFinished;
    }