using Builder.BehaviorInterfaces;

namespace Builder {
    public class NPC {
        private readonly IAttackBehavior attackBehavior;
        private readonly IMovementBehavior movementBehavior;
        private readonly IInteractBehavior interactBehavior;
        private readonly IDamagedBehavior damagedBehavior;

        private NPC(IBuilder builder) {
            attackBehavior = builder.GetAttackBehavior();
            movementBehavior = builder.GetMovementBehavior();
            interactBehavior = builder.GetInteractBehavior();
            damagedBehavior = builder.GetDamagedBehavior();
        }

        public void Attack() {
            attackBehavior.Attack();
        }

        public void Move() {
            movementBehavior.Move();
        }

        public void Interact() {
            interactBehavior.Interact();
        }

        public void Damaged() {
            damagedBehavior.Damaged();
        }

        public interface IBuilder {
            IAttackBehavior GetAttackBehavior();
            IDamagedBehavior GetDamagedBehavior();
            IInteractBehavior GetInteractBehavior();
            IMovementBehavior GetMovementBehavior();
        } 
        
        public sealed class Builder : IBuilder {
            private IAttackBehavior attackBehavior;
            private IDamagedBehavior damagedBehavior;
            private IInteractBehavior interactBehavior;
            private IMovementBehavior movementBehavior;

            public Builder WithAttackBehavior(IAttackBehavior ab) {
                this.attackBehavior = ab;
                return this;
            }

            public Builder WithDamagedBehavior(IDamagedBehavior db) {
                this.damagedBehavior = db;
                return this;
            }

            public Builder WithInteractBehavior(IInteractBehavior ib) {
                this.interactBehavior = ib;
                return this;
            }

            public Builder WithMovementBehavior(IMovementBehavior mb) {
                this.movementBehavior = mb;
                return this;
            }

            public NPC Build() {
                return new NPC(this);
            }

            public IAttackBehavior GetAttackBehavior() {
                return attackBehavior;
            }

            public IDamagedBehavior GetDamagedBehavior() {
                return damagedBehavior;
            }

            public IInteractBehavior GetInteractBehavior() {
                return interactBehavior;
            }

            public IMovementBehavior GetMovementBehavior() {
                return movementBehavior;
            }
        }
    }
}