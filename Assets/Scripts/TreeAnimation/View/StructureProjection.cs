using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeAnimation.View
{
    public class StructureProjection : MonoBehaviour
    {
        public void Start()
        {

        }
        public void Update()
        {

        }

        public void CreateTreeProjection(List<int> animationList){

        }

        public void CreateNodeProjection()
        {
            GameObject prefab = Resources.Load("Prefabs/NodePrefab") as GameObject;
        }
    }
}