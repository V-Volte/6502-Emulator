using System;
using static CPUEmu.Declarations;
using static CPUEmu.Memory;

namespace CPUEmu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ushort a = 0xeaff;
            byte b = (byte)a;
            Console.WriteLine(b.ToString("X"));
            b = (byte)(a >> 8);
            Console.WriteLine(b.ToString("X"));

            StatusRegister acc = new StatusRegister();
            acc.Set();
            acc.ClearZero();
            acc.print();
            systemMemory.Write(acc, 0xffff);
            acc.Set(0xab);
            systemMemory.Write(acc, 0xfffa);
            acc.print();
            systemMemory.Read(acc, 0xffff);
            acc.print();

        }
    }
}
