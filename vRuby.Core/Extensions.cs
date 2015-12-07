using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace tw.nyan.vRuby.Core
{
	/// <summary>
	/// vRuby Extension Methods
	/// </summary>
	public static class Extensions
    {
        #region Byte

        /// <summary>
		/// Returns a string containing the representation of fix radix base.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="ibase"></param>
		/// <returns></returns>
		public static String to_s(this Byte self, Int32 ibase = 10)
		{
			return Convert.ToString(self, ibase);
		}

		#endregion Byte

		#region DateTime

		/// <summary>
		/// Alias for Time.at
		/// </summary>
		/// <param name="self"></param>
		/// <param name="seconds_with_frac"></param>
		/// <returns></returns>
		public static DateTime at(this DateTime self, Int32 seconds_with_frac)
		{
			return Time.at(seconds_with_frac);
		}
		/// <summary>
		/// Returns the value of time as an double number of seconds since the Epoch.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static Double to_double(this DateTime self)
		{
			return (self - new DateTime(1970, 1, 1)).TotalSeconds;
		}
		/// <summary>
		/// Returns the value of time as an uint number of seconds since the Epoch.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static UInt32 to_uint(this DateTime self)
		{
			return Convert.ToUInt32(self.to_double());
		}

		#endregion DateTime

		#region Hashtable

		/// <summary>
		/// Validate all keys in a hash match *valid keys, raising ArgumentError on a mismatch. Note that keys are NOT treated indifferently, meaning if you use strings for keys but assert symbols as keys, this will fail.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="valid_keys"></param>
		public static void assert_valid_keys(this Hashtable self, Hashtable valid_keys)
		{
			ICollection keyColl = self.Keys;
			foreach (String k in keyColl)
			{
				if (!valid_keys.ContainsKey(k))
					throw new ArgumentException("Unknown key: " + k);
			}
		}

		#endregion Hashtable

		#region Int32

		/// <summary>
		/// Returns the absolute value of Int32.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static Int32 abs(this Int32 self)
		{
			return Math.Abs(self);
		}
		/// <summary>
		/// Returns an array containing the quotient and modulus obtained by dividing num by numeric. If q, r = x.divmod(y), then
		/// </summary>
		/// <param name="self"></param>
		/// <param name="numeric"></param>
		/// <returns></returns>
		public static Int32[] divmod(this Int32 self, Int32 numeric)
		{
			int[] n = new int[2];

			n[0] = self / numeric;
			n[1] = self % numeric;

			return n;
		}
		/// <summary>
		/// Returns the Integer equal to int + 1.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static Int32 next(this Int32 self)
		{
			return self++;
		}
		/// <summary>
		/// Returns a string containing the representation of fix radix base.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="ibase"></param>
		/// <returns></returns>
		public static String to_s(this Int32 self, Int32 ibase = 10)
		{
			return Convert.ToString(self, ibase);
		}
		/// <summary>
		/// Returns true if fix is zero.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static bool zero2(this Int32 self)
		{
			return (self == 0) ? true : false;
		}

		#endregion Int32

		#region String

		/// <summary>
		/// Returns a copy of str with the first character converted to uppercase and the remainder to lowercase. Note: case conversion is effective only in ASCII region.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static String capitalize(this String self)
		{
			if (!String.IsNullOrEmpty(self))
			{
				if (self.Length > 1)
				{
					return self.Substring(0, 1).ToUpper() + self.Substring(1, self.Length - 1).ToLower();
				}
				else
				{
					return self.ToUpper();
				}
			}
			return self;
		}
		/// <summary>
		/// Returns a copy of str with all uppercase letters replaced with their lowercase counterparts. The operation is locale insensitive—only characters ``A’’ to ``Z’’ are affected. Note: case replacement is effective only in ASCII region.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static String downcase(this String self)
		{
			return self.ToLower();
		}
		/// <summary>
		/// Treats leading characters from str as a string of hexadecimal digits (with an optional sign and an optional 0x) and returns the corresponding number. Zero is returned on error.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static Int32 hex(this String self)
		{
			try
			{
				return Convert.ToInt32(self, 16);
			}
			catch
			{
				return 0;
			}
		}
		/// <summary>
		/// Both forms iterate through str, matching the pattern (which may be a Regexp or a String). For each match, a result is generated and either added to the result array or passed to the block. If the pattern contains no groups, each individual result consists of the matched string, $＆. If the pattern contains groups, each individual result is itself an array containing one entry per group.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static String[] scan(this String self)
		{
			Regex regex = new Regex(@"\..\");
			MatchCollection mc = regex.Matches(self, 0);
			foreach (Match match in mc)
			{

			}
			return null;
		}
		/// <summary>
		/// Returns the result of interpreting leading characters in str as an integer base base (between 2 and 36).
		/// Extraneous characters past the end of a valid number are ignored.
		/// If there is not a valid number at the start of str, 0 is returned.
		/// This method never raises an exception when base is valid.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="ibase"></param>
		/// <returns></returns>
		public static Int32 to_i(this String self, Int32 ibase = 10)
		{
			return Convert.ToInt32(self, ibase);
		}
		/// <summary>
		/// Both forms iterate through str, matching the pattern (which may be a Regexp or a String).
		/// For each match, a result is generated and either added to the result array or passed to the block.
		/// If the pattern contains no groups, each individual result consists of the matched string, $&amp;.
		/// If the pattern contains groups, each individual result is itself an array containing one entry per group.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="pattern"></param>
		/// <param name="replacement"></param>
		/// <returns></returns>
		public static String sub(this String self, String pattern, String replacement)
		{
			return new Regex(pattern).Replace(self, replacement);
		}
		/// <summary>
		/// Returns a copy of str with all lowercase letters replaced with their uppercase counterparts. The operation is locale insensitive—only characters ``a’’ to ``z’’ are affected. Note: case replacement is effective only in ASCII region.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static String upcase(this String self)
		{
			return self.ToUpper();
		}

		#endregion String

		#region UInt16

		/// <summary>
		/// Returns the Integer equal to int + 1.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static UInt16 next(this UInt16 self)
		{
			return self++;
		}
		/// <summary>
		/// Returns a string containing the representation of fix radix base.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="ibase"></param>
		/// <returns></returns>
		public static String to_s(this UInt16 self, Int32 ibase = 10)
		{
			return Convert.ToString(self, ibase);
		}

		#endregion UInt16

		#region UInt32

		/// <summary>
		/// Returns the Integer equal to int + 1.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static UInt32 next(this UInt32 self)
		{
			return self++;
		}
		/// <summary>
		/// Returns a string containing the representation of fix radix base.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="ibase"></param>
		/// <returns></returns>
		public static String to_s(this UInt32 self, Int32 ibase = 10)
		{
			return Convert.ToString(self, ibase);
		}

		#endregion UInt32
	}
}
