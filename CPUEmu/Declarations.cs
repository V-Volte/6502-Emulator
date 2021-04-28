using System;
using System.Collections.Generic;
using System.Text;

namespace CPUEmu
{
    class Declarations
    {
        public static StatusRegister statusRegister = new StatusRegister();
        public static Memory systemMemory = new Memory();
        public static ProgramCounter programCounter = new ProgramCounter();
        public static StackPointer stackPointer = new StackPointer();
    }
}
