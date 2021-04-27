using System;
using System.Collections.Generic;
using System.Text;
using static CPUEmu.Declarations;

namespace CPUEmu
{
    
    class Memory
    {
        private byte[] memory = new byte[0x10000];

        public bool Write(Register8 register, ushort location)
        {
            if (IsWriteToStack(location)) return false;
            if (location > 0xffff)
            {
                statusRegister.SetOverflow();
                return false;
            }

            memory[location] = register.Get();

            return true;
        }

        public bool Write(Register16 register, ushort location)
        {
            if (IsWriteToStack(location)) return false;
            if (location >= 0xffff)
            {
                statusRegister.SetOverflow();
                return false;
            }
            memory[location] = register.GetLow();
            memory[location + 1] = register.GetHigh();

            return true;
        }

        public bool Read(Register8 register, ushort location)
        {
            if (location > 0xffff)
            {
                statusRegister.SetOverflow();
                return false;
            }

            register.Set(memory[location]);
            return true;

        }

        private bool IsWriteToStack(ushort location)
        {
            return location < 0x0100;
        }


    }
}
