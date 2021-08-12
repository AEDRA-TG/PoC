using UnityEngine;
using System.Collections.Generic;
using TreeAnimation.Model;
using TreeAnimation.Controller;

namespace TreeAnimation.View
{
    public class ViewObserverManager : MonoBehaviour
    {

        private List<int> animationList;
        private StructureProjection _structureProjection;

        private void Awake()
        {
            this.animationList = new List<int>();
            this._structureProjection = FindObjectOfType<StructureProjection>();
        }
        private void OnEnable()
        {
            NodeA.OperationNotifier += AddObject;
            TreeControllerA.OperationNotifier += OnOperationComplete;

        }
        private void OnDisable()
        {
            NodeA.OperationNotifier -= AddObject;
            TreeControllerA.OperationNotifier -= OnOperationComplete;
        }

        //Add elements to animationList
        private void AddObject(int ID)
        {
            animationList.Add(ID);
        }

        private void OnOperationComplete()
        {
            this._structureProjection.CreateTreeProjection(this.animationList);
            animationList.Clear();
        }


    }
}