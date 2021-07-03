using System;
using Builder.BehaviorInterfaces;
using Builder.ConcreteBehaviors;
using UnityEngine;

namespace Builder {
    public class CharacterBuilder : MonoBehaviour {
        public NPC customNPC;
        public NPCType NpcType = default;
        
        public enum NPCType {
           Hammond,
           Dridd
        }

        private void Start() {
            customNPC = NpcType switch {
                NPCType.Dridd => Dridd(gameObject),
                NPCType.Hammond => Hammond(gameObject),
                _ => customNPC
            };
        }

        private void FixedUpdate() {
           customNPC.Move(); 
        }

        public NPC Dridd(GameObject go) {
            // be able to:
            // move
            // attack
            // player detected

            NPC npc = new NPC.Builder()
                .WithAttackBehavior(new DrillAttackBehavior())
                .WithMovementBehavior(new PatrolBehavior())
                .WithRigidBody2D(go)
                .WithBoxCollider2D(go)
                .Build();

            return npc;
        }

        public NPC Hammond(GameObject go) {
            NPC npc = new NPC.Builder()
                .WithAttackBehavior(new HammondAttackBehavior())
                .WithMovementBehavior(new AggressiveMovementBehavior())
                .WithRigidBody2D(go)
                .WithBoxCollider2D(go)
                .Build();

            return npc;
        }
    }

    public class HammondAttackBehavior : IAttackBehavior {
        public void Attack(NPC npc) {
           Debug.Log("attacked!".CustomLog(Color.green)); 
        }
    }

    public class PatrolBehavior : IMovementBehavior {
        public void Move(NPC npc) {
            npc.RB.AddForce(Vector2.right, ForceMode2D.Impulse);
        }
    }

    public class DrillAttackBehavior : IAttackBehavior {
        public void Attack(NPC npc) {
        }
    }
}