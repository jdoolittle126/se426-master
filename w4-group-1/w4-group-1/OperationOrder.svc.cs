using System.ServiceModel;

namespace w4_group_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class OperationOrderService : IOperationOrder
    {
        private int totalsum = 0;

        public void Initialize(int a)
        {
            totalsum = a;
        }
        public int Add(int a, int b)
        {
            totalsum = a + b + totalsum;
            return totalsum;
        }


        public int Multiply(int a, int b)
        {
            return a * b;
        }


        public int AddTwo(int a)
        {
            return a + 2;
        }


        public int MultiplyTwo(int a)
        {
            return a * 2;
        }
    }
}

