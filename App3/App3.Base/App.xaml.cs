using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;

namespace App3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeLogging();

            // Works in WASDK but not WASM. It crashes with the following exception:
            /*
              Uncaught (in promise)    at Windows.ApplicationModel.Resources.ResourceLoader.GetCulturesHierarchy(CultureInfo culture)+MoveNext() in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 202
                 at System.Linq.Enumerable.DistinctIterator`1[[System.String, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].MoveNext() in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\System.Linq\src\System\Linq\Distinct.cs:line 122
                 at System.Collections.Generic.LargeArrayBuilder`1[[System.String, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].AddRange(IEnumerable`1 items) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\Common\src\System\Collections\Generic\LargeArrayBuilder.SizeOpt.cs:line 30
                 at System.Collections.Generic.EnumerableHelpers.ToArray[String](IEnumerable`1 source) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\Common\src\System\Collections\Generic\EnumerableHelpers.Linq.cs:line 84
                 at System.Linq.Enumerable.ToArray[String](IEnumerable`1 source) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\System.Linq\src\System\Linq\ToCollection.cs:line 17
                 at Windows.ApplicationModel.Resources.ResourceLoader.ReloadResources(CultureInfo current, String defaultLanguage) in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 231
                 at Windows.ApplicationModel.Resources.ResourceLoader.EnsureLoadersCultures() in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 221
                 at Windows.ApplicationModel.Resources.ResourceLoader.GetString(String resource) in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 66
                 at App3.App..ctor() in D:\Repos\App3\App3\App3.Base\App.xaml.cs:line 27
                 at App3.Wasm.Program.<>c.<Main>b__1_0(ApplicationInitializationCallbackParams _) in D:\Repos\App3\App3\App3.Wasm\Program.cs:line 12
                 at Microsoft.UI.Xaml.Application.StartPartial(ApplicationInitializationCallback callback) in /home/vsts/work/1/s/src/Uno.UI/UI/Xaml/Application.wasm.cs:line 96
                 at Microsoft.UI.Xaml.Application.Start(ApplicationInitializationCallback callback) in /home/vsts/work/1/s/src/Uno.UI/UI/Xaml/Application.cs:line 250
                 at App3.Wasm.Program.Main(String[] args) in D:\Repos\App3\App3\App3.Wasm\Program.cs:line 15
                 at System.Reflection.MethodInvoker.InterpretedInvoke(Object obj, Span`1 args, BindingFlags invokeAttr) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\mono\System.Private.CoreLib\src\System\Reflection\MethodInvoker.Mono.cs:line 33
              Error: Object reference not set to an instance of an object.
                  at marshal_exception_to_js (http://localhost:5000/package_c51c4451ab742c57949c79f77eea28ccd666013f/dotnet.js:5:53791)
                  at invoke_method_and_handle_exception (http://localhost:5000/package_c51c4451ab742c57949c79f77eea28ccd666013f/dotnet.js:5:77192)
                  at runtimeHelpers.javaScriptExports.call_entry_point (http://localhost:5000/package_c51c4451ab742c57949c79f77eea28ccd666013f/dotnet.js:5:80525)
                  at Bootstrapper.mono_run_main [as _runMain] (http://localhost:5000/package_c51c4451ab742c57949c79f77eea28ccd666013f/dotnet.js:5:3270)
                  at Bootstrapper.mainInit (http://localhost:5000/package_c51c4451ab742c57949c79f77eea28ccd666013f/uno-bootstrap.js:370:30)
              VM80:1 
                      
              fail: Uno.UI.Dispatching.CoreDispatcher[0]
                    Dispatcher unhandled exception
              System.NullReferenceException: Object reference not set to an instance of an object.
                 at Windows.ApplicationModel.Resources.ResourceLoader.GetCulturesHierarchy(CultureInfo culture)+MoveNext() in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 202
                 at System.Linq.Enumerable.DistinctIterator`1[[System.String, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].MoveNext() in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\System.Linq\src\System\Linq\Distinct.cs:line 122
                 at System.Collections.Generic.LargeArrayBuilder`1[[System.String, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].AddRange(IEnumerable`1 items) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\Common\src\System\Collections\Generic\LargeArrayBuilder.SizeOpt.cs:line 30
                 at System.Collections.Generic.EnumerableHelpers.ToArray[String](IEnumerable`1 source) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\Common\src\System\Collections\Generic\EnumerableHelpers.Linq.cs:line 84
                 at System.Linq.Enumerable.ToArray[String](IEnumerable`1 source) in D:\a\Uno.DotnetRuntime.WebAssembly\Uno.DotnetRuntime.WebAssembly\runtime\src\libraries\System.Linq\src\System\Linq\ToCollection.cs:line 17
                 at Windows.ApplicationModel.Resources.ResourceLoader.ReloadResources(CultureInfo current, String defaultLanguage) in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 231
                 at Windows.ApplicationModel.Resources.ResourceLoader.EnsureLoadersCultures() in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 221
                 at Windows.ApplicationModel.Resources.ResourceLoader.GetString(String resource) in /home/vsts/work/1/s/src/Uno.UWP/ApplicationModel/Resources/ResourceLoader.cs:line 66
                 at App3.App.OnLaunched(LaunchActivatedEventArgs args) in D:\Repos\App3\App3\App3.Base\App.xaml.cs:line 50
                 at Microsoft.UI.Xaml.Application.Initialize() in /home/vsts/work/1/s/src/Uno.UI/UI/Xaml/Application.wasm.cs:line 128
                 at Uno.UI.Dispatching.CoreDispatcher.InvokeOperationSafe(UIAsyncOperation operation) in /home/vsts/work/1/s/src/Uno.UI.Dispatching/Core/CoreDispatcher.cs:line 342
             */
            //var resourceLoader = ResourceLoader.GetForViewIndependentUse("App3/Resources");
            //var localizedText = resourceLoader.GetString("ApplicationName");

            this.InitializeComponent();

#if HAS_UNO || NETFX_CORE
            this.Suspending += OnSuspending;
#endif
        }

        /// <summary>
        /// Gets the main window of the app.
        /// </summary>
        internal static Window MainWindow { get; private set; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Works in WASDK but not WASM. It returns an empty string.
            var resourceLoader = ResourceLoader.GetForViewIndependentUse("App3/Resources");
            var localizedText = resourceLoader.GetString("ApplicationName");

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

#if NET6_0_OR_GREATER && WINDOWS && !HAS_UNO
            MainWindow = new Window();
            MainWindow.Activate();
#else
            MainWindow = Microsoft.UI.Xaml.Window.Current;
#endif

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (MainWindow.Content is not Frame rootFrame)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (args.UWPLaunchActivatedEventArgs.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                MainWindow.Content = rootFrame;
            }

#if !(NET6_0_OR_GREATER && WINDOWS)
            if (args.UWPLaunchActivatedEventArgs.PrelaunchActivated == false)
#endif
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), args.Arguments);
                }
                // Ensure the current window is active
                MainWindow.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new InvalidOperationException($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        /// <summary>
        /// Configures global Uno Platform logging
        /// </summary>
        private static void InitializeLogging()
        {
#if DEBUG
            // Logging is disabled by default for release builds, as it incurs a significant
            // initialization cost from Microsoft.Extensions.Logging setup. If startup performance
            // is a concern for your application, keep this disabled. If you're running on web or 
            // desktop targets, you can use url or command line parameters to enable it.
            //
            // For more performance documentation: https://platform.uno/docs/articles/Uno-UI-Performance.html

            var factory = LoggerFactory.Create(builder =>
            {
#if __WASM__
                builder.AddProvider(new global::Uno.Extensions.Logging.WebAssembly.WebAssemblyConsoleLoggerProvider());
#elif __IOS__ && !__MACCATALYST__
                builder.AddProvider(new global::Uno.Extensions.Logging.OSLogLoggerProvider());
#elif NETFX_CORE
                builder.AddDebug();
#else
                builder.AddConsole();
#endif

                // Exclude logs below this level
                builder.SetMinimumLevel(LogLevel.Information);

                // Default filters for Uno Platform namespaces
                builder.AddFilter("Uno", LogLevel.Warning);
                builder.AddFilter("Windows", LogLevel.Warning);
                builder.AddFilter("Microsoft", LogLevel.Warning);

                // Generic Xaml events
                // builder.AddFilter("Windows.UI.Xaml", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.UIElement", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.FrameworkElement", LogLevel.Trace );

                // Layouter specific messages
                // builder.AddFilter("Windows.UI.Xaml.Controls", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Controls.Panel", LogLevel.Debug );

                // builder.AddFilter("Windows.Storage", LogLevel.Debug );

                // Binding related messages
                // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );

                // Binder memory references tracking
                // builder.AddFilter("Uno.UI.DataBinding.BinderReferenceHolder", LogLevel.Debug );

                // RemoteControl and HotReload related
                // builder.AddFilter("Uno.UI.RemoteControl", LogLevel.Information);

                // Debug JS interop
                // builder.AddFilter("Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug );
            });

            global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory = factory;

#if HAS_UNO
            global::Uno.UI.Adapter.Microsoft.Extensions.Logging.LoggingAdapter.Initialize();
#endif
#endif
        }
    }
}
