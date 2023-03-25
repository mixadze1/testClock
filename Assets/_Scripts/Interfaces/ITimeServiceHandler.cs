using System;
using System.Threading.Tasks;

public interface ITimeServiceHandler
{
    Task<DateTime> GetTime();
}