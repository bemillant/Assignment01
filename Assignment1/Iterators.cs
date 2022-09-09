namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        //temp ugly solution, refactor this later
        var UglyList = new List<T>(); 
        foreach (IEnumerable<T> item in items)
        {
            foreach (T thing in item){
                UglyList.Add(thing);
            }
        }
        return UglyList;
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) => throw new NotImplementedException(); 
}