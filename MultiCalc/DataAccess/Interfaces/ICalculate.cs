using System;

namespace DataAccess.Contexts
{
    public interface ICalculate
    {
        void Calc(Guid personId, string a, string b, string operation, string result);
    }
}