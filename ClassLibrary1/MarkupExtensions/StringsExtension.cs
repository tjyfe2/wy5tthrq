// File generated automatically by ReswPlus. https://github.com/DotNetPlus/ReswPlus
using System;
using Windows.ApplicationModel.Resources;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Data;

namespace ClassLibrary1.MarkupExtensions
{
    [System.CodeDom.Compiler.GeneratedCode("DotNetPlus.ReswPlus", "2.1.3")]
    [System.Diagnostics.DebuggerNonUserCode()]
    [System.Runtime.CompilerServices.CompilerGenerated()]
    [MarkupExtensionReturnType(ReturnType = typeof(string))]
    public class StringsExtension : MarkupExtension
    {
        public enum KeyEnum
        {
            __Undefined = 0,
            ApplicationName = 1,
            ToggleSwitchOff = 2,
            ToggleSwitchOn = 3,
        }

        private static ResourceLoader _resourceLoader;
        static StringsExtension()
        {
            _resourceLoader = ResourceLoader.GetForViewIndependentUse("ClassLibrary1/Resources");
        }
        public KeyEnum Key { get; set; }
        public IValueConverter Converter { get; set; }
        public object ConverterParameter { get; set; }
        protected override object ProvideValue()
        {
            return "The markup extension works.";
        }
    }
}
