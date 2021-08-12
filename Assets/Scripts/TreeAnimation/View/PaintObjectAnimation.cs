using UnityEngine;
using DG.Tweening;
using TreeAnimation.Utils;

namespace TreeAnimation.View
{
    public class PaintObjectAnimation : MonoBehaviour, IAnimationStrategy
    {
        private int _idObjectToPaint;

        public Color ColorToPaint{get; set;}
        public PaintObjectAnimation(int idToPaint, Color colorToPaint)
        {
            this._idObjectToPaint = idToPaint;
            this.ColorToPaint = colorToPaint;
        }

        public Tween Animate()
        {
            GameObject objectToPaint = GameObject.Find("Node_"+this._idObjectToPaint);
            return ChangeColor(objectToPaint);
        }

        private Tween ChangeColor(GameObject obj){
            MeshRenderer mesh = obj.GetComponentInChildren<MeshRenderer>();
            mesh.material = new Material(Shader.Find("Standard"));
            Tween animation = mesh.material.DOColor(this.ColorToPaint, 1).OnComplete(() =>
            mesh.material.DOColor(ConstansA.UnPaintObjectColor, 1).SetDelay(2f));
            return animation;
        }
    }
}