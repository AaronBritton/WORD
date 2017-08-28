using Ninject;
using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The IoC container for out application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernal for our IoC Container
        /// </summary>
        public static IKernel Kernal { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as our application starts up to ensure all
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singletone view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernal.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        /// <summary>
        /// Gets a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernal.Get<T>();
        }
    }
}
