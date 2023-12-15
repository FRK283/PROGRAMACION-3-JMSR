using UnityEngine;

namespace JosueMartin
{
    public class Collectible : MonoBehaviour, IRecollectable
    {

        public Item itemReference;

        public Item Pick()
        {

            return itemReference;

        }

    }

}
