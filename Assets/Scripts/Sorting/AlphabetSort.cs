using System;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetSort : MonoBehaviour
{
    // chatgpt helped me with some of this code (namely the .Compare method, using "do", and almost all of the code for AlphabeticalSearch)

    public Node[] items = new Node[1];
    public int pointer = 0;
    public void Add(Node node)
    {
        if (pointer > items.Length - 1)
        {
            Node[] newList = new Node[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                newList[i] = items[i];
            }

            items = newList;
        }
        items[pointer] = node;
        pointer++;
    }

    void Start()
    {
        Node head = new Node("hp", 1, "Rare");
        head.Next = new Node("Atk", 1, "Epic");
        head.Next.Next = new Node("stone", 1, "Common");
        head.Next.Next.Next = new Node("stick", 1, "Common");
        head = SortAlphabetically(head);

        Node current = head;
        while (current != null)
        {
            Debug.Log(current.Name);
            current = current.Next;
        }

        Debug.Log($"index of \"stone\": {AlphabeticalSearch(head, "stone")}");

        head.Next.Next.Next.Next = new Node("testobj", 1, "Rare");
        Debug.Log($"index of \"testobj\": {AlphabeticalSearch(head, "testobj")}");


    }

    // bubblesort
    public Node SortAlphabetically(Node head)
    {
        if (head == null || head.Next == null)
            return head;  // if the list is empty/contains only one node it's already sorted

        bool swapped;
        do
        {
            swapped = false;
            Node current = head;
            Node prev = null;
            Node nextNode = current?.Next; // "?" is so the code won't explode if current.Next happens to be null

            while (nextNode != null)
            {
                // compare nodes alphabetically by Name
                if (string.Compare(current.Name, nextNode.Name) > 0)
                {
                    // swap
                    if (prev != null)
                    {
                        prev.Next = nextNode;
                    }
                    current.Next = nextNode.Next;
                    nextNode.Next = current;

                    // update head if necessary
                    if (prev == null)
                    {
                        head = nextNode;
                    }

                    swapped = true;
                }
                prev = current;
                current = current.Next;
                nextNode = current?.Next;
            }
        } while (swapped);

        return head; // when sorted, return head with all the .next's
    }

    // linear search
    public int AlphabeticalSearch(Node head, string targetName) // chatgpt wrote this
        // so according to chatgpt it is really hard to binary search in a linked list apparently
        // hence why this is not a binary search, i tried to make the code work for it but after like an hour with no progress i kind of just gave up
    {
        int index = 0;
        Node current = head;

        // Traverse the sorted linked list
        while (current != null)
        {
            // Check if the current node's Name matches the target
            if (current.Name.Equals(targetName, System.StringComparison.OrdinalIgnoreCase))
            {
                return index; // Return the index if found
            }

            // Move to the next node and increment the index
            current = current.Next;
            index++;
        }

        return -1; // Return -1 if the target is not found
    }
}
