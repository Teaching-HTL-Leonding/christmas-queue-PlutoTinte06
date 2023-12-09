namespace ChristmasQueue.Collections;

internal class ListNode
{
    public Stack Stack { get; }

    public ListNode? Next { get; set; }

    public ListNode(int maxStackHeight)
    {
        Stack = new(maxStackHeight);
    }
}

public class ListOfStacks
{
    private ListNode? First { get; set; }
    private int NumberOfStacks { get; }

    public ListOfStacks(int numberOfStacks, int maxStackHeight)
    {
        NumberOfStacks = numberOfStacks;
        First = new ListNode(maxStackHeight);

        var current = First;

        for (var i = 1; i < numberOfStacks; i++)
        {
            current.Next = new ListNode(maxStackHeight);
            current = current.Next;
        }
    }

    public Stack? GetAt(int stackIndex)
    {
        var current = First;

        for (var i = 0; i < stackIndex; i++)
        {
            if (current == null)
            {
                return null;
            }

            current = current?.Next;
        }
        return current?.Stack;
    }

    public bool AreAllStacksHomogeneous()
    {
        var current = First;

        while (current != null)
        {
            if (!current.Stack.IsHomogeneous())
            {
                return false;
            }

            current = current.Next;
        }

        return true;
    }
}
