﻿using System;
using System.IO;

/* Copyright (c) 2012 CBaxter
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
 * IN THE SOFTWARE. 
 */

namespace Harvester.Core.Messaging.Sources.DbWin
{
    internal static class UnmanagedMemoryAccessorExtensions
    {
        public static Byte[] ReadBuffer(this UnmanagedMemoryAccessor memoryAccessor)
        {
            Verify.NotNull(memoryAccessor, "memoryAccessor");
            
            var result = new Byte[memoryAccessor.Capacity];
            
            memoryAccessor.ReadArray(0, result, 0, result.Length);

            return result;
        }

        public static void WriteBuffer(this UnmanagedMemoryAccessor memoryAccessor, Byte[] buffer)
        {
            Verify.NotNull(memoryAccessor, "memoryAccessor");
            Verify.NotNull(buffer, "buffer");

            memoryAccessor.WriteArray(0, buffer, 0, Math.Min(buffer.Length, (Int32)memoryAccessor.Capacity));
        }
    }
}
