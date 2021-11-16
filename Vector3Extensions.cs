using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static List<Vector3> AddVector(this List<Vector3> vectorList, Vector3 addedVector){
        // Adds the given vector to every element in the list
        List<Vector3> sumVector = new List<Vector3>();
        foreach(Vector3 vect in vectorList){
            sumVector.Add(vect + addedVector);
        }
        return sumVector;
    }
    public static List<Vector3> AddVector(this List<Vector3> vectorList, float addedX, float addedY, float addedZ){
        // Adds the given vector to every element in the list
        List<Vector3> sumVector = new List<Vector3>();
        foreach(Vector3 vect in vectorList){
            sumVector.Add(vect + new Vector3(addedX, addedY, addedZ));
        }
        return sumVector;
    }

    
    public static Vector3 ProjectHorizontal(this Vector3 inVector){
        // Projects the input vector onto the XZ plane
        return Vector3.ProjectOnPlane(inVector, Vector3.up);
    }


    public static Vector3 Average(this List<Vector3> vectorList){
        // Calculates the average of all vectors in the list
        Vector3 sum = Vector3.zero;
        int numItems = vectorList.Count;

        foreach(Vector3 item in vectorList){
            sum += item;
        }

        return sum / numItems;
    }


    public static Vector3 MaxComponents(this List<Vector3> vectorList){
        // Returns the maximum x, y, and z component of the Vectors contained in the given list
        float xMax = Mathf.NegativeInfinity;
        float yMax = Mathf.NegativeInfinity;
        float zMax = Mathf.NegativeInfinity;

        foreach(Vector3 currVector in vectorList){
            xMax = Mathf.Max(xMax, currVector.x);
            yMax = Mathf.Max(yMax, currVector.y);
            zMax = Mathf.Max(zMax, currVector.z);
        }

        return new Vector3(xMax, yMax, zMax);
    }

    public static Vector3 MinComponents(this List<Vector3> vectorList){
        // Returns the maximum x, y, and z component of the Vectors contained in the given list
        float xMin = Mathf.Infinity;
        float yMin = Mathf.Infinity;
        float zMin = Mathf.Infinity;

        foreach(Vector3 currVector in vectorList){
            xMin = Mathf.Min(xMin, currVector.x);
            yMin = Mathf.Min(yMin, currVector.y);
            zMin = Mathf.Min(zMin, currVector.z);
        }

        return new Vector3(xMin, yMin, zMin);
    }


    public static List<Vector3> TransformPoints(this Transform transform, List<Vector3> localVectors){
        // Transforms a list of positions from world space to local space
        List<Vector3> worldVectors = new List<Vector3>();

        foreach(Vector3 localVector in localVectors){
            Vector3 newVector = transform.TransformPoint(localVector);
            worldVectors.Add(newVector);
        }

        return worldVectors;
    }

    public static List<Vector3> InverseTransformPoints(this Transform transform, List<Vector3> worldVectors){
        /// Transforms a list of positions from world space to local space
        List<Vector3> localVectors = new List<Vector3>();

        foreach(Vector3 worldVector in worldVectors){
            Vector3 newVector = transform.InverseTransformPoint(worldVector);
            localVectors.Add(newVector);
        }

        return localVectors;
    }
}
