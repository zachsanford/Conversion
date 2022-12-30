// <copyright file="Binary.cs" company="Zachary Sanford">
// Copyright (c) Zachary Sanford. All rights reserved.
// </copyright>

namespace Conversion.Core.Shared;

/// <summary>
/// Class that handles binary functionality.
/// </summary>
public class Binary
{
    /// <summary>
    /// Converts a string of 8 bits into decimal notation.
    /// </summary>
    /// <param name="input">8 bit string.</param>
    /// <returns>Decimal notation representation of the parameter.</returns>
    public int BinaryToDecimal(string input)
    {
        int runningSum = 0;

        // Test the string
        if (IsEightBitString(input))
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() != "0")
                {
                    runningSum += GetBitPositionValue(i);
                }
            }
        }

        return runningSum;
    }

    /// <summary>
    /// Tests the input's length and characters if it represents
    /// an 8 bit number.
    /// </summary>
    /// <param name="input">String to test.</param>
    /// <returns>Boolean value that is the outcome of the test.</returns>
    /// <exception cref="ArgumentException">Throws length error and character error.</exception>
    private static bool IsEightBitString(string input)
    {
        // Check the length first
        if (input.Length == 8)
        {
            bool isBit = false;

            // Check each char to see if it represents a bit
            foreach (char i in input)
            {
                if (i.ToString() == "1" || i.ToString() == "0")
                {
                    isBit = true;
                }
                else
                {
                    throw new ArgumentException(message: $"The argument contains the character {i.ToString()}. Is should only consist of {{ 0, 1 }}.", paramName: nameof(input));
                }
            }

            if (isBit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new ArgumentException(message: $"The argument length is {input.Length}. It needs to be eight characters long.", paramName: nameof(input));
        }
    }

    /// <summary>
    /// Gets the bit positions decimal notation value.
    /// </summary>
    /// <param name="position">The position index within the 8 bit string.</param>
    /// <returns>Decimal notation value.</returns>
    private static int GetBitPositionValue(int position)
    {
        int returnValue = position switch
        {
            0 => 128,
            1 => 64,
            2 => 32,
            3 => 16,
            4 => 8,
            5 => 4,
            6 => 2,
            7 => 1,
            _ => 0
        };

        return returnValue;
    }
}
