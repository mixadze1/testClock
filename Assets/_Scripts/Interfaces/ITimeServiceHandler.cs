using System;
using System.Threading.Tasks;

namespace Assets._Scripts.Interfaces
{
    public interface ITimeServiceHandler
    {
        Task<DateTime> GetTime();
    }
}