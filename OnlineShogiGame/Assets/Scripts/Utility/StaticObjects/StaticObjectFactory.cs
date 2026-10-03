using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility.StaticObjects
{
    /// <summary>
    /// StaticObjectファクトリークラス
    /// </summary>
    public class StaticObjectFactory : StaticObject<StaticObjectFactory>
    {
        [SerializeField, Header("StaticObjectPrefabリスト")]
        private List<StaticObjectBase> ObjectList_ = new();

        /// <summary>
        /// インスタンス生成時実行関数
        /// </summary>
        private void Awake()
        {
            //  リスト内オブジェクト一括生成
            foreach (var obj in ObjectList_)
            {
                Instantiate(obj);
            }

            //  生成したら自身は削除
            Destroy(gameObject);
        }
    }

}