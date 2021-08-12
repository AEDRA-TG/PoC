using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TreeAnimation.View
{
    public class StructureProjection : MonoBehaviour
    {
        private List<Tween> _dotTweenAnimationList;

        private void Awake(){
            this._dotTweenAnimationList = new List<Tween>();
        }
        public void Start()
        {
        }
        public void Update()
        {

        }

        public void ExecuteAnimations(List<IAnimationStrategy> animationList){
            foreach(IAnimationStrategy animation in animationList){
                Tween anim = animation.Animate();
                if(anim != null){
                    this._dotTweenAnimationList.Add(anim);
                }
            }
            Sequence animationSequence = DOTween.Sequence();
            foreach (Tween animation in this._dotTweenAnimationList)
            {
                animationSequence.Append(animation);
            }
        }
    }
}