﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Czarina.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class XML {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal XML() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Czarina.Tests.XML", typeof(XML).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;samples&gt;
        ///  &lt;states&gt;
        ///    &lt;state&gt;
        ///      &lt;name&gt;New York&lt;/name&gt;
        ///      &lt;abbr&gt;NY&lt;/abbr&gt;
        ///      &lt;cities&gt;
        ///        &lt;city&gt;Manhattan&lt;/city&gt;
        ///        &lt;city&gt;Queens&lt;/city&gt;
        ///        &lt;city&gt;Bronx&lt;/city&gt;
        ///        &lt;city&gt;Staten Island&lt;/city&gt;
        ///        &lt;city&gt;Brooklyn&lt;/city&gt;
        ///      &lt;/cities&gt;
        ///    &lt;/state&gt;
        ///    &lt;state&gt;
        ///      &lt;name&gt;North Carolina&lt;/name&gt;
        ///      &lt;abbr&gt;NC&lt;/abbr&gt;
        ///      &lt;cities&gt;
        ///        &lt;city&gt;Greensboro&lt;/city&gt;
        ///        &lt;city&gt;Durham&lt;/city&gt;
        ///        &lt;city&gt;Raleigh&lt;/city&gt;
        ///  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string states {
            get {
                return ResourceManager.GetString("states", resourceCulture);
            }
        }
    }
}
