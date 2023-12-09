namespace ChristmasQueue.Collections;

internal class StackNode
{
    public string Content { get; }

    public StackNode? Next { get; set; }

    public StackNode(string content)
    {
        Content = content;
    }
}

public class Stack
{

    private StackNode? First { get; set; }
    private int MaxHeight { get; }

    public Stack(int maxHeight)
    {
        MaxHeight = maxHeight;
    }

    public bool TryPush(string content)
    {
        if (IsFull)
        {
            return false;
        }
        else
        {
            StackNode newNode = new StackNode(content);
            newNode.Next = First;
            First = newNode;
            return true;
        }
    }

    public bool TryPop(out string content)
    {
        content = "";

        if (IsEmpty)
        {
            return false;
        }
        else
        {
            content = First!.Content;
            First = First?.Next;
            return true;
        }
    }

    public string? Peek(int depth)
    {
        var current = First;
        for (int i = 0; i < depth; i++)
        {
            if (current == null)
            {
                return null;
            }
            current = current.Next;
        }
        return current?.Content;
    }

    public bool IsEmpty => First == null;

    public bool IsFull => Count() == MaxHeight;

    public bool IsHomogeneous()
    {
        if (IsEmpty)
        {
            return true;
        }
        else
        {
            var current = First;

            while (current != null)
            {
                if (current.Content != First?.Content)
                {
                    return false;
                }

                current = current.Next;
            }
            return true;
        }
    }

    private int Count()
    {
        int count = 0;
        var current = First;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }
}
