using ReGoap.Unity.FSMExample.Actions;

namespace ReGoap.Unity.FSMExample.Agents {

    public class BuilderAgent : ReGoapAgentAdvanced<string, object> {
        // TODO: research if it's easy to access all the preconditions/effects of
        // all the actions on a gameObject

        private CraftRecipeAction[] recipes;

        protected override void Awake() {
            base.Awake();
            recipes = GetComponents<CraftRecipeAction>();
        }

        protected override bool CalculateNewGoal(bool forceStart = false) {
            System.Random random = new System.Random();

            foreach (CraftRecipeAction recipe in recipes) {
                recipe.Cost = random.Next(1, 10);
            }

            return base.CalculateNewGoal(forceStart);
        }
    }
}
