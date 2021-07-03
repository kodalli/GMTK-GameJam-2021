using Builder.BehaviorInterfaces;

namespace Builder.ConcreteBehaviors {
    public class ExplosiveDamagedBehavior : IDamagedBehavior{
        public void Damaged(NPC npc) {
            throw new System.NotImplementedException();
        }
    }
}