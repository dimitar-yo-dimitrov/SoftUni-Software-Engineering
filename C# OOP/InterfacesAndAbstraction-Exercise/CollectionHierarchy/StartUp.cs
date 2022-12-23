using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            var engine = new Engine(
                addCollection,
                addRemoveCollection,
                myList);

            engine.Run();
        }
    }
}
