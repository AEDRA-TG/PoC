using UnityEngine;
using System.Collections.Generic;
using TreeAnimation.Model;
using TreeAnimation.Controller;

namespace TreeAnimation.View
{
    public class ViewObserverManager : MonoBehaviour
    {

        private List<IAnimationStrategy> animationList;
        private StructureProjection _structureProjection;

        private void Awake()
        {
            this.animationList = new List<IAnimationStrategy>();
            this._structureProjection = FindObjectOfType<StructureProjection>();
        }
        private void OnEnable()
        {
            NodeA.OperationNotifier += AddObject;
            TreeA.OperationNotifier += AddObject;
            TreeControllerA.OperationNotifier += OnOperationComplete;

        }
        private void OnDisable()
        {
            NodeA.OperationNotifier -= AddObject;
            TreeA.OperationNotifier -= AddObject;
            TreeControllerA.OperationNotifier -= OnOperationComplete;
        }

        //Add elements to animationList
        private void AddObject(IAnimationStrategy objectAnimation)
        {
            animationList.Add(objectAnimation);
        }

        private void OnOperationComplete()
        {
            this._structureProjection.ExecuteAnimations(this.animationList);
            animationList.Clear();
        }


    }
}