using UnityEngine;
using TreeAnimation.Utils;
using DG.Tweening;

namespace TreeAnimation.View
{
    public class CreateObjectAnimation : MonoBehaviour, IAnimationStrategy
    {
        private int _idObjectToCreate;
        private int _idFatherObject;
        public CreateObjectAnimation(int idToCreate)
        {
            this._idObjectToCreate = idToCreate;
            this._idFatherObject = 0;
        }

        public CreateObjectAnimation(int idToCreate, int idFatherObject){
            this._idObjectToCreate = idToCreate;
            this._idFatherObject = idFatherObject;
        }

        public Tween Animate()
        {
            GameObject objectPrefab = Resources.Load(ConstansA.PathNodeAPrefab) as GameObject;
            return InstanciateObject(objectPrefab, "TestTree", "Node_" + this._idObjectToCreate);
            /*if(_idFatherObject != 0){
                
            }*/
        }

        private Tween InstanciateObject(GameObject prefab, string parent, string objectName){
            GameObject newObject = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
            newObject.transform.parent = GameObject.Find(parent).transform;
            newObject.name = objectName;
            return null;
        }
    }
}