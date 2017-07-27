using System.Collections.Generic;
using UnityEngine;

namespace ReGoap.Unity.FSMExample.Agents {
    public class BuilderAgent : ReGoapAgentAdvanced<string, object> {
        public float fleeDistance = 10.0f;
        bool forceWander = false;

        protected override void Update() {
            base.Update();

            float? sqrDistanceToScaryAgent = memory.GetWorldState().Get("sqrDistanceToScaryAgent") as float?;

            if (sqrDistanceToScaryAgent.HasValue && sqrDistanceToScaryAgent < fleeDistance * fleeDistance && currentGoal.GetPriority() < 100) {
                forceWander = true;
                CalculateNewGoal(true);
            }
        }

        protected override bool CalculateNewGoal(bool forceStart = false) {
            ReprioritizeGoals();
            return base.CalculateNewGoal(forceStart);
        }

        private void ReprioritizeGoals() {
            List<ReGoapGoal<string, object>> goals = new List<ReGoapGoal<string, object>>(GetComponents<ReGoapGoal<string, object>>());

            foreach (var goal in goals) {
                if (forceWander && goal.Name == "WanderGoal") {
                    goal.Priority = 100.0f;
                    forceWander = false;
                    break;
                }

                goal.Priority = Random.Range(1.0f, 10.0f);
            }
        }
    }
}  