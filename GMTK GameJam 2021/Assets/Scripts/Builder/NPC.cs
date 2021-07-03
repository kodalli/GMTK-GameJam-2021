using Builder.BehaviorInterfaces;
using UnityEngine;

namespace Builder {
    public class NPC {
        private readonly IAttackBehavior attackBehavior;
        private readonly IMovementBehavior movementBehavior;
        private readonly IInteractBehavior interactBehavior;
        private readonly IDamagedBehavior damagedBehavior;
        private readonly Rigidbody2D rigidbody2D;
        private readonly BoxCollider2D collider2D;
        public Rigidbody2D RB => rigidbody2D;
        public BoxCollider2D Collider => collider2D;

        private NPC(IBuilder builder) {
            attackBehavior = builder.GetAttackBehavior();
            movementBehavior = builder.GetMovementBehavior();
            interactBehavior = builder.GetInteractBehavior();
            damagedBehavior = builder.GetDamagedBehavior();
            rigidbody2D = builder.GetRigidBody2D();
            collider2D = builder.GetBoxCollider2D();
        }

        #region Behaviors

        public void Attack() => attackBehavior.Attack(this);

        public void Move() => movementBehavior.Move(this);

        public void Interact() => interactBehavior.Interact(this);

        public void Damaged() => damagedBehavior.Damaged(this);

        #endregion

        private interface IBuilder {
            IAttackBehavior GetAttackBehavior();
            IDamagedBehavior GetDamagedBehavior();
            IInteractBehavior GetInteractBehavior();
            IMovementBehavior GetMovementBehavior();
            Rigidbody2D GetRigidBody2D();
            BoxCollider2D GetBoxCollider2D();
        }

        public sealed class Builder : IBuilder {
            private IAttackBehavior attackBehavior;
            private IDamagedBehavior damagedBehavior;
            private IInteractBehavior interactBehavior;
            private IMovementBehavior movementBehavior;
            private Rigidbody2D rigidbody2D;
            private BoxCollider2D collider2D;

            public NPC Build() {
                return new NPC(this);
            }

            #region Behavior Setters

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

            public Builder WithRigidBody2D(GameObject go) {
                rigidbody2D = go.AddComponent<Rigidbody2D>();
                return this;
            }

            public Builder WithBoxCollider2D(GameObject go) {
                collider2D = go.AddComponent<BoxCollider2D>();
                return this;
            }

            #endregion

            #region Behavior Getters

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

            public Rigidbody2D GetRigidBody2D() {
                return rigidbody2D;
            }

            public BoxCollider2D GetBoxCollider2D() {
                return collider2D;
            }

            #endregion
        }
    }
}