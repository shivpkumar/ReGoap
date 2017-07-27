using System.Collections.Generic;
using ReGoap.Unity.FSMExample.OtherScripts;
using UnityEngine;

namespace ReGoap.Unity.FSMExample.Sensors
{
    public class ScaryAgentSensor : ReGoapSensor<string, object>
    {
        private GameObject scaryAgent;

        void Start() {
            scaryAgent = GameObject.Find("ScaryAgent");
        }

        public override void UpdateSensor() {
            memory.GetWorldState().Set("sqrDistanceToScaryAgent", (scaryAgent.transform.position - transform.position).sqrMagnitude);
        }
    }
}