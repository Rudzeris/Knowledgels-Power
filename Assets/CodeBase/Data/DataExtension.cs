using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3Data ToVector3Data(this Vector3 vector3) 
            => new(vector3.x, vector3.y, vector3.z);
        public static Vector3 ToVector3(this Vector3Data vector3Data)
           => new Vector3(vector3Data.x, vector3Data.y, vector3Data.z);

        public static T ToDeserialized<T>(this string json) 
            => JsonUtility.FromJson<T>(json);
    }
}