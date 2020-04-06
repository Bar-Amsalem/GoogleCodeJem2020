namespace CondeJem2020Qualify.Q4.Sim
{
    public class TestMemoryChanger : IMemoryChanger
    {
        readonly ArrayAction[] allActions = new ArrayAction[]
        {
            ArrayAction.Complemented,
            ArrayAction.Reverse,
            ArrayAction.ReverseComplemented,
            ArrayAction.None
        };

        int lastIndex = 0;

        public ArrayAction GetActionToPreform()
        {
            return allActions[lastIndex++ % allActions.Length];
        }
    }




}
