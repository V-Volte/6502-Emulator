using System;
using static CPUEmu.Declarations;
using static CPUEmu.Memory;

namespace CPUEmu
{
    class Program
    {
        static void Main(string[] args)
        {
            Accumulator a = new Accumulator();
            a.Set(0xff);
            stackPointer.Push(a);
            systemMemory.Write(a, 0xffff);
            a.Set(0xab);
            systemMemory.Write(a, 0xfffa);
            a.Set(0xea);
            stackPointer.Push(a);
            a.print();
            stackPointer.Pull(a);
            a.print();
            stackPointer.Pull(a);
            a.print();
            systemMemory.Read(a, 0xfffa);
            a.print();
            systemMemory.Read(a, 0x00fe);
            a.print();

            //statusRegister.print();

            //a.Load(0x00);
            //a.print();
            //a.Add(0xea);
            //a.print();

            //a.AddCarry(0xff);
            //a.Add(0xff);

            //a.Subtract(0xff);

            //statusRegister.print();

        }
    }
}
