using Builder.BehaviorInterfaces;

namespace Builder.ConcreteBehaviors {
    public class ExplosiveDamagedBehavior : IDamagedBehavior{
        public void Damaged() {
            throw new System.NotImplementedException();
        }
    }
}