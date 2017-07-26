using System;
using ReGoap.Core;
using UnityEngine;

namespace ReGoap.Unity.FSMExample.Actions {
    
    public class WanderAction : ReGoapAction<string, object> {
        public float timeToPause = 1.0f;
        private float wanderCooldown;

        protected override void Awake() {
            base.Awake();
            effects.Set("wandered", true);
        }

        public override ReGoapState<string, object> GetPreconditions(ReGoapState<string, object> goalState, IReGoapAction<string, object> next = null) {
            preconditions.Set("isAtPosition", randomPosition());
            return preconditions;
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, IReGoapActionSettings<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail) {
            base.Run(previous, next, settings, goalState, done, fail);
            wanderCooldown = Time.time + timeToPause;
        }

        void Update() {
            if (Time.time > wanderCooldown) {
                doneCallback(this);
            }
        }

        private Vector3 randomPosition() {
            System.Random random = new System.Random();
            return new Vector3(random.Next(10, 90), 0, random.Next(10, 90));
        }
    }
}