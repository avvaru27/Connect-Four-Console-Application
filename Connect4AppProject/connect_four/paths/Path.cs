namespace ConsoleApp.connect_four.paths;

public abstract class Path
{
    protected readonly Dictionary<Char, List<int>> ValidationHashMap = new();
    
    protected  int PathIndex;

    public virtual List<Tuple<int, int>>? AddEntry(Char entry, int? indexData = null, object? extras = null)
    {
        if (ValidationHashMap.TryGetValue(entry, out var value))
        {
            value.Add(indexData!.Value);
        }
        else
        {
            ValidationHashMap[entry] = [indexData!.Value];
        }
        

        return ValidateEntries(entry);
    }

    protected List<Tuple<int, int>>? ValidateEntries(Char entry , Object? extras = null)
    {

        ValidationHashMap[entry].Sort();
        var listToValidate = ValidationHashMap[entry];
        int length = listToValidate.Count;
        var index = 0;
        var currentValue = listToValidate[index];
        index++;
        var possibleConnect4Count = 1;
        while (index < length)
        {
            if (listToValidate[index] == currentValue + 1)
            {
                possibleConnect4Count++;
                
                currentValue = listToValidate[index];
            }
            
            index++;
        }
        if (possibleConnect4Count == 4)
        {
            return AddConnected4Paths(entry , extras);
        }
        
        return null;
    }


    protected abstract List<Tuple<int, int>>? AddConnected4Paths(Char entry , Object? extras = null);
}