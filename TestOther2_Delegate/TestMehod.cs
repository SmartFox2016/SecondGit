namespace TestOther2_Delegate
{
    /// <summary>
    ///  IEatable接口
    /// </summary>
    interface IEatable
    {
        void Eat();
    }
    /// <summary>
    ///   IWalkable接口
    /// </summary>
    interface IWalkable
    {
        void Walk();
    }
    /// <summary>
    /// IAnimal接口
    /// </summary>
    interface IAnimal:IEatable,IWalkable
    {
        void Run();
    }
    class Cat
    {
        int Age;
        
    }
}