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

        internal void Reload(API api, ref double maxValue)
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
     static readonly Dictionary<uint, Measure> Measures = new Dictionary<uint, Measure>();
        public static void Initialize(ref IntPtr data, IntPtr rm)
        {
            var id = (uint)*data;
            Measures.Add(id, new Measure());
            Measures[id].Initialize(new API((IntPtr)rm));
            //data = GCHandle.ToIntPtr(GCHandle.Alloc(new Measure(new API(rm))));
        }

        public static void Finalize(IntPtr data)
        {
            var id = (uint)data;
            Measures[id].Finalize();
            Measures.Remove(id);
            //GCHandle.FromIntPtr(data).Free();
        }

        public static void Reload(IntPtr data, IntPtr rm, ref double maxValue)
        {
            var id = (uint)data;
            Measures[id].Reload(new API((IntPtr)rm), ref *maxValue);
            //((Measure)GCHandle.FromIntPtr(data).Target).Reload(new API(rm), ref maxValue);
        }

        public static double Update(IntPtr data)
        {
            var id = (uint)data;
            return Measures[id].GetDouble();
            //return ((Measure)GCHandle.FromIntPtr(data).Target).Update();
        }

        public static string GetString(IntPtr data)
        {
            //var id = (uint)data;
            //fixed (char* s = Measures[id].GetString()) return s;
            //return ((Measure)GCHandle.FromIntPtr(data).Target).GetString();
            return "";
        }

        public static void ExecuteBang(IntPtr data, string args) 
        {
            //var id = (uint)data;
            //Measures[id].ExecuteBang(new string(args));
            //((Measure)GCHandle.FromIntPtr(data).Target).ExecuteBang(args);
        }
    }
}
