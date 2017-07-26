using System.Collections.Generic;

namespace ReGoap.Unity.FSMExample.Agents {
    public class BuilderAgent : ReGoapAgentAdvanced<string, object> {
        protected override bool CalculateNewGoal(bool forceStart = false) {
            ReprioritizeGoals();
            base.CalculateNewGoal(forceStart);
            return true;
        }

        private void ReprioritizeGoals() {
            List<ReGoapGoal<string, object>> goals = new List<ReGoapGoal<string, object>>(GetComponents<ReGoapGoal<string, object>>());

            foreach (var goal in goals) {
                goal.Priority = UnityEngine.Random.Range(1.0f, 10.0f);
            }
        }
    }
}  