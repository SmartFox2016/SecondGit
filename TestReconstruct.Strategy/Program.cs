using System;
using System.Collections.Generic;
using System.Linq;

namespace TestReconstruct.Strategy
{
    /*
     * Dscription:这种重构在设计模式当中把它单独取了一个名字——策略模式，这样做的好处就是可以隔开耦合，
     *   以注入的形式实现功能，这使增加功能变得更加容易和简便，同样也增强了整个系统的稳定性和健壮性。
     * Created By Flying on 2018-04-11 
     * 备注：只是自己尚未明白
     */

    public interface IShippingInfo
    {
        decimal CalculateShippingAmount(State state);
    }
    public class ClientCode
    {
       // [Inject] MVC和ORM框架，秒杀：在1秒内被抢光，秒爱，秒懂
        public IShippingInfo ShippingInfo { get; set; }
       
        public decimal CalculateShipping()
        {
            return ShippingInfo.CalculateShippingAmount(State.Alaska);
        }
    }

    public enum State 
    {
        Alaska,
        NewYork,
        Florida
    }
    //
    public class ShippingInfo : IShippingInfo
    {
        private IDictionary<State, IShippingCalculation> ShippingCalculations { get; set; }

        public ShippingInfo(IEnumerable<IShippingCalculation> shippingCalculations)
        {

            ShippingCalculations = shippingCalculations.ToDictionary(calc => calc.State);

        }

        public decimal CalculateShippingAmount(State shipToState)
        {

            return ShippingCalculations[shipToState].Calculate();

        }

        
    }

    public interface IShippingCalculation
    {

        State State { get; }

        decimal Calculate();

    }



    public class AlaskShippingCalculation : IShippingCalculation

    {
        public State State { get { return State.Alaska; } }
        public decimal Calculate()

        {

            return 15m;

        }

    }


    //应该如此调试，但也不为过
    public class NewYorkShippingCalculation : IShippingCalculation

    {

        public State State { get { return State.NewYork; } }



        public decimal Calculate()

        {

            return 10m;

        }

    }


    //山寨和创新的本质不在于抄袭和模仿，最根本在于是否对问题和需求有真正理解 
    public class FloridaShippingCalculation : IShippingCalculation

    {

        public State State { get { return State.Florida; } }



        public decimal Calculate()

        {

            return 3m;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
