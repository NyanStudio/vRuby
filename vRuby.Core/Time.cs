using System;

namespace tw.nyan.vRuby.Core
{
	/// <summary>
	/// Time is an abstraction of dates and times. Time is stored internally as the number of seconds with fraction since the Epoch, January 1, 1970 00:00 UTC. Also see the library modules Date. The Time class treats GMT (Greenwich Mean Time) and UTC (Coordinated Universal Time)[Yes, UTC really does stand for Coordinated Universal Time. There was a committee involved.] as equivalent. GMT is the older way of referring to these baseline times but persists in the names of calls on POSIX systems.
	/// All times may have fraction. Be aware of this fact when comparing times with each other—times that are apparently equal when displayed may be different when compared.
	/// </summary>
	public class Time
	{
		/// <summary>
		/// Creates a new time object with the value given by time, the given number of seconds_with_frac, or seconds and microseconds_with_frac from the Epoch. seconds_with_frac and microseconds_with_frac can be Integer, Float, Rational, or other Numeric. non-portable feature allows the offset to be negative on some systems
		/// </summary>
		/// <param name="seconds_with_frac"></param>
		/// <returns></returns>
		public static DateTime at(Int32 seconds_with_frac)
		{
			return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(seconds_with_frac);
		}
		/// <summary>
		/// Creates a new time object with the value given by time, the given number of seconds_with_frac, or seconds and microseconds_with_frac from the Epoch. seconds_with_frac and microseconds_with_frac can be Integer, Float, Rational, or other Numeric. non-portable feature allows the offset to be negative on some systems
		/// </summary>
		/// <param name="seconds_with_frac"></param>
		/// <returns></returns>
		public static DateTime at(UInt32 seconds_with_frac)
		{
			return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(seconds_with_frac);
		}
	}
}
