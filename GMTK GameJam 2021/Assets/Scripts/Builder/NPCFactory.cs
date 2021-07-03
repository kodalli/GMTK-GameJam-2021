using Builder.ConcreteBehaviors;

namespace Builder {
    public class NPCFactory {
        public NPC BuildBod() {
            NPC bob = new NPC.Builder()
                .WithAttackBehavior(new MeleeAttackBehavior())
                .WithDamagedBehavior(new ExplosiveDamagedBehavior())
                .WithInteractBehavior(new TalkativeInteractBehavior())
                .WithMovementBehavior(new AggressiveMovementBehavior())
                .Build();
            
            bob.Attack();
            bob.Damaged();
            bob.Interact();
            bob.Move();
            return bob;
        }

        public NPC BuildCockBoy() {
            NPC cocker = new NPC.Builder()
                .WithAttackBehavior(new CockAttackBehavior())
                .Build();
            
            cocker.Attack();
            return cocker;
        }
    }
}