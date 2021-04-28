using System;
using System.Collections.Generic;
using System.Text;
using static CPUEmu.Declarations;

namespace CPUEmu
{
    class Accumulator : Register8
    {
        public void Add(ushort location)
        {
            byte b = systemMemory.GetByte(location);
            if ((int)internalRegister + (int)b > 0xff) statusRegister.SetOverflow();
            internalRegister += b;
        }

        public void Add(byte b)
        {
            if ((int)((int)internalRegister + (int)b) > 0xff) statusRegister.SetOverflow();
            internalRegister += b;
        }

        public void AddCarry(ushort location)
        {
            byte b = systemMemory.GetByte(location);
            if ((int)internalRegister + (int)b > 0xff) statusRegister.SetCarry();
            internalRegister += b;
        }

        public void AddCarry(byte b)
        {
            if ((int)((int)internalRegister + (int)b) > 0xff) statusRegister.SetCarry();
            internalRegister += b;
        }

        public void Subtract(ushort location)
        {
            byte b = systemMemory.GetByte(location);
            if (b > internalRegister) statusRegister.SetOverflow();
            internalRegister -= b;
        }

        public void SubtractBorrow(ushort location)
        {
            byte b = systemMemory.GetByte(location);
            internalRegister -= b;
            if ((int) ((int) (internalRegister) - (int) (b)) < 0)
            {
                statusRegister.SetCarry();
            }
        }

        public void Subtract(byte b)
        {
            if (b > internalRegister) statusRegister.SetSign();
            else statusRegister.ClearSign();
            internalRegister -= b;
        }

        public void SubtractBorrow(byte b)
        {
            if (b > internalRegister) statusRegister.SetSign();
            else statusRegister.ClearSign();
            internalRegister -= b;
            if ((int)((int)(internalRegister) - (int)(b)) < 0)
            {
                statusRegister.SetCarry();
            }
        }

        public void Load(byte b)
        {
            internalRegister = b;
        }

        public void Load(ushort location)
        {
            Load(systemMemory.GetByte(location));
        }
    }
}
