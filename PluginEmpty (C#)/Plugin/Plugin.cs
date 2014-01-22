using System;
using System.Runtime.InteropServices;
using Rainmeter;

// Overview: This is a blank canvas on which to build your plugin.

// Note: Measure.GetString, Measure.ExecuteBang, and parts of Plugin.GetString and
// Plugin.ExecuteBang have been commented out. If you need GetString
// and/or ExecuteBang and you have read what they are used for from the
// SDK docs, uncomment the function(s). Otherwise leave them commented out
// (or get rid of them)!

namespace Plugin
{
    internal class Measure
    {
        internal Measure(API api)
        {
            
        }

        internal void Reload(ref double maxValue)
        {

        }

        internal double Update()
        {
            return 0.0;
        }

        //internal string GetString()
        //{
        //    return "";
        //}

        //internal void ExecuteBang(string args)
        //{
        //}
    }

    public static class Plugin
    {
        public static void Initialize(ref IntPtr data, IntPtr rm)
        {
            data = GCHandle.ToIntPtr(GCHandle.Alloc(new Measure(new API(rm))));
        }

        public static void Finalize(IntPtr data)
        {
            GCHandle.FromIntPtr(data).Free();
        }

        public static void Reload(IntPtr data, IntPtr rm, ref double maxValue)
        {
            ((Measure)GCHandle.FromIntPtr(data).Target).Reload(ref maxValue);
        }

        public static double Update(IntPtr data)
        {
            return ((Measure)GCHandle.FromIntPtr(data).Target).Update();
        }

        public static string GetString(IntPtr data)
        {
            //return ((Measure)GCHandle.FromIntPtr(data).Target).GetString();
            return "";
        }

        public static void ExecuteBang(IntPtr data, string args) 
        {
            //((Measure)GCHandle.FromIntPtr(data).Target).ExecuteBang(args);
        }
    }
}
