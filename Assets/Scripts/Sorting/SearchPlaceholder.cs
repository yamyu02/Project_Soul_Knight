using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this could probably be used for an inventory system or something along those lines

public class SearchPlaceholder : MonoBehaviour
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

    public static int BinarySearch(int[] arr, int num)
    {
        int l = 0;
        int r = arr.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            if (arr[m] == num)
            {
                // Console.WriteLine($"Found element at {m}");
                return m;
            }
            else if (num > arr[m])
            {
                // Console.WriteLine($"Given element {num} greater than {m}, increasing lowest");
                l = m + 1;
            }
            else
            {
                // Console.WriteLine($"Given element {num} smaller than {m}, decreasing highest");
                r = m - 1;
            }
        }
        return -1; // if the loop never found the element (i.e. the element does not exist in the list)
    }
}
