namespace ReGoap.Unity.FSMExample.Goals {

    public class WanderGoal : ReGoapGoal<string, object> {
        protected override void Awake() {
            base.Awake();
            goal.Set("wandered", true);
        }

        public override string ToString() {
            return string.Format("GoapGoal('{0}')", Name);
        }
    }
}