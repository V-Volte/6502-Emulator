using System;
using System.Collections.Generic;
using System.Text;


namespace CPUEmu
{
    abstract class Register8
    {
        public Register8()
        {
            internalRegister = 0;
        }
        protected byte internalRegister = 0;
        public void Flush()
        {
            internalRegister = 0;
        }
        public void Set()
        {
            internalRegister = 0xff;
        }

        public void Set(byte n)
        {
            internalRegister = n;
        }

        public byte Get()
        {
            return internalRegister;
        }

        public void print()
        {
            Console.WriteLine(internalRegister.ToString("X"));
        }
    }

    abstract class Register16
    {
        public Register16()
        {
            internalRegister = 0;
        }
        protected ushort internalRegister = 0;
        public void Flush()
        {
            internalRegister = 0;
        }

        public void ClearHigh()
        {
            internalRegister &= 0x0f;
        }

        public void ClearLow()
        {
            internalRegister &= 0xf0;
        }

        public void Set()
        {
            internalRegister = 0xffff;
        }

        public void SetHigh()
        {
            internalRegister |= 0xff00;
        }

        public void SetLow()
        {
            internalRegister |= 0x00ff;
        }
        public void Set(ushort n)
        {
            internalRegister = n;
        }

        public void SetHigh(byte n)
        {
            ClearHigh();
            ushort temp = n;
            temp <<= 8;
            internalRegister |= temp;
        }

        public void SetLow(byte n)
        {
            ClearLow();
            ushort temp = n;
            internalRegister |= temp;
        }

        public byte GetHigh()
        {
            return (byte)(internalRegister >> 8);
        }

        public byte GetLow()
        {
            return (byte)(internalRegister);
        }

        public void print()
        {
            Console.WriteLine(internalRegister.ToString("X"));
        }
    }

    class ProgramCounter : Register16
    {
        public void Increment()
        {
            internalRegister++;
        }
    }

    
}
