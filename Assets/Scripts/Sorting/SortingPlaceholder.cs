// note: "sorting by two or more properties" means sorting something by integers but taking multiple variables into account
// (such as speed, health, damage, etc) and using a formula to normalize it into a single integer for each distinct value
// (("two or more properties" does not mean "sort by character" or whatever i initially thought))


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingPlaceholder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int[] ConvertToInts(int[] arr1, int[] arr2)
    {
        int[] newarr = new int[arr1.Length];
        // some formula would turn the two int arrays into a single one (assuming they are the same length)
        for (int i = 0; i < newarr.Length; i++)
        {
            newarr[i] = (arr1[i] + 2 * arr2[i]) / 2; // would probably look something like this but not really
        }
        return newarr;
    }

    public static void SelectionSort(int[] arr) // this is what we were taught in class you would just have to put a formula somewhere to account for two or more properties
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[min] > arr[j])
                {
                    min = j;
                }
            }
            int n = arr[i];
            arr[i] = arr[min];
            arr[min] = n;
        }
    }
}
