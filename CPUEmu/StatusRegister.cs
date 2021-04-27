using System;
using System.Collections.Generic;
using System.Text;

namespace CPUEmu
{
    class StatusRegister : Register8
    {

        public StatusRegister(byte n)
        {
            internalRegister = n;
        }

        public StatusRegister()
        {
            internalRegister = 0;
        }

        public void SetZero()
        {
            internalRegister |= 0b00000001;
        }

        public void SetIRQ()
        {
            internalRegister |= 0b00000010;
        }

        public void SetBreak()
        {
            internalRegister |= 0b00000100;
        }

        public void SetSign()
        {
            internalRegister |= 0b00010000;
        }

        public void SetDecimal()
        {
            internalRegister |= 0b00100000;
        }

        public void SetOverflow()
        {
            internalRegister |= 0b01000000;
        }

        public void SetCarry()
        {
            internalRegister |= 0b10000000;
        }

        public void ClearZero()
        {
            internalRegister &= 0b11111110;
        }

        public void ClearIRQ()
        {
            internalRegister &= 0b11111101;
        }

        public void ClearBreak()
        {
            internalRegister &= 0b11111011;
        }

        public void ClearSign()
        {
            internalRegister &= 0b11101111;
        }

        public void ClearDecimal()
        {
            internalRegister &= 0b11011111;
        }

        public void ClearOverflow()
        {
            internalRegister &= 0b10111111;
        }

        public void ClearCarry()
        {
            internalRegister &= 0b01111111;
        }
    }
}
