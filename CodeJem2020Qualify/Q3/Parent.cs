namespace CondeJem2020Qualify.Q3
{
    public class Parent
    {
        public char Name { get;  }
        readonly Clock clock;

        public Parent(char name, Clock clock)
        {
            this.Name = name;
            this.clock = clock;
        }

        public Activity AssainActivity { get; set; }

        public bool IsBusy
        {
            get
            {
                return AssainActivity != null &&
                    AssainActivity.Start <= clock.Time &&
                    AssainActivity.Stop > clock.Time;
            }
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
