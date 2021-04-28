using System;
using System.Collections.Generic;
using System.Text;
using static CPUEmu.Declarations;

namespace CPUEmu
{

    // An instance of the class Memory defines the 64KB of system memory accessible by the 6502 microprocessor
    
    class Memory
    {
        //A byte array of size 64k, representing the 64k of system memory

        private byte[] memory = new byte[0x10000];

        //Write the contents of an 8-bit register to memory

        public bool Write(Register8 register, ushort location)
        {
            //If the operation is a write to the stack, the write fails.
            if (IsWriteToStack(location)) return false;
            if (location > 0xffff)
            {
                //Sets the overflow flag on the status register
                statusRegister.SetOverflow();
                return false;
            }

            memory[location] = register.Get();

            return true;
        }

        //Write the contents of a 16-bit register to memory
        //Unused, just here in case the program counter needs to be written to memory

        public bool Write(Register16 register, ushort location)
        {
            //If the operation is a write to the stack, the write fails.
            if (IsWriteToStack(location)) return false;
            if (location >= 0xffff)
            {
                //Sets the overflow flag on the status register
                statusRegister.SetOverflow();
                return false;
            }
            memory[location] = register.GetLow();
            memory[location + 1] = register.GetHigh();

            return true;
        }

        //Read from memory into an 8 bit register

        public bool Read(Register8 register, ushort location)
        {
            if (location > 0xffff)
            {
                //Sets the overflow flag on the status register
                statusRegister.SetOverflow();
                return false;
            }

            register.Set(memory[location]);
            return true;

        }

        public byte GetByte(ushort location)
        {
            if (location > 0xffff)
            {
                //Sets the overflow flag on the status register
                statusRegister.SetOverflow();
                return 0;
            }

            return memory[location];
        }

        //Checks if a write operation is a write to the stack
        private bool IsWriteToStack(ushort location)
        {
            return location < 0x0100;
        }

        //Function for the Stack Pointer to write to memory
        public bool StackWrite(Register8 register, ushort location)
        {
            memory[location] = register.Get();
            return true;
        }

        //Function for the Stack Pointer to read from memory
        //Probably not needed as reads from stack are fine
        //with normal Read, but here for symmetry
        public bool StackRead(Register8 register, ushort location)
        {
            register.Set(memory[location]);
            return true;
        }



    }

    class StackPointer : Register8
    {
        public StackPointer()
        {
            //Initializing the stack pointer to the last location on the stac, 0xff
            //It goes above from there until address 0x00
            internalRegister = 0xff;
        }
        public void Increment()
        {
            if (internalRegister == 0x00)
            {
                statusRegister.SetBreak();
            }
            internalRegister--;
        }

        public void Decrement()
        {
            if(internalRegister == 0xff)
            {
                statusRegister.SetBreak();
            }
            internalRegister++;
        }

        //Push the contents of a register to the stack
        public void Push(Register8 register)
        {
            //The current push function always ignores location 0xff
            //Effectively reducing the stack space available by one byte
            //TODO: Fix this, making location 0xff usable
            Increment();
            systemMemory.StackWrite(register, internalRegister);

            //Sets the zero flag on the status register
            if (register.Get() == 0) statusRegister.SetZero();            
        }

        //Pull from memory to a register
        public void Pull(Register8 register)
        {
            systemMemory.StackRead(register, internalRegister);
            if (register.Get() == 0) statusRegister.SetZero();
            Decrement();
        }

    }
}
