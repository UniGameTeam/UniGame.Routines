﻿using System.Collections;
using UnityEngine;

namespace UniModules.UniRoutine.Examples.UpdateExamples
{
    using System.Collections.Generic;
    using Runtime;

    public class UpdateRoutineExample : MonoBehaviour
    {
        public int         updateCount;
        public int         routineCount;
        public RoutineType RoutineType = RoutineType.Update;
        public List<RoutineHandle> RoutineHandlers = new List<RoutineHandle>();
            
        // Start is called before the first frame update
        private void Start()
        {
            for (int i = 0; i < routineCount; i++) {
                var handler = OnUpdate(i).Execute(RoutineType, false);
                RoutineHandlers.Add(handler);
            }
        }

        private void OnDisable()
        {
            RoutineHandlers.ForEach(x => x.Cancel());
            RoutineHandlers.Clear();
        }

        private IEnumerator OnUpdate(int number)
        {
            var counter = 0;
            while (true) {
                counter++;
                if (counter > updateCount) {
                    Debug.Log($"ROUTINE: COUNTER #{number} {RoutineType} FINISHED");
                    yield break;
                }

                yield return OnSome();
                yield return null;
            }
        }

        private IEnumerator OnSome()
        {
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }
        
    }
}
