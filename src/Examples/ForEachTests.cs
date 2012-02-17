using System.Collections.Generic;
using pUnit;

namespace Examples
{
    [ProfileClass]
    public class ForEachTests
    {
        [ProfileMethod]
        public void ForTest()
        {
            List<int> list = GetNumberList();

            for (int i = 0; i < list.Count; i++)
            {
            }
        }

        [ProfileMethod]
        public void ForEachTest()
        {
            List<int> list = GetNumberList();

            foreach (int i in list)
            {
            }
        }

        private List<int> GetNumberList()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}