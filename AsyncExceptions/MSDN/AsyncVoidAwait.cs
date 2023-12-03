namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncVoidAwait
    {
static Type type = typeof(AsyncVoidAwait);
        /// <summary>
        /// To že je metoda async nevadí, vadí await
        /// </summary>
        private async void ThrowExceptionAsync()
        {
            await Task.Delay(1);
            ThrowEx.Custom("");
        }
        public void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                ThrowExceptionAsync();
            }
            catch (Exception ex)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}
