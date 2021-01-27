namespace PortKiller
{
    public class BindData
    {
        public string ProcessName { set; get; }
        public int Pid { set; get; }
        public string Space { set; get; }

        public BindData()
        {
        }

        public BindData(string processName, int pid, string space)
        {
            ProcessName = processName;
            Pid = pid;
            Space = space;
        }

        public override string ToString()
        {
            return "BindData: {\"Pid\":\"" + Pid + "\",\"ProcessName\":\"" + ProcessName + "\",\"Space\":\"" + Space + "\"}";
        }
    }
}
