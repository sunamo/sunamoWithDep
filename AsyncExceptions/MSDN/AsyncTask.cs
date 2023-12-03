namespace AsyncExceptions.MSDN
{
    /// <summary>
    /// In UWP throw UnhandledException
    /// </summary>
    class AsyncTask
    {
static Type type = typeof(AsyncTask);
        private async Task ThrowExceptionAsync()
        {
            await Task.Delay(1);
            // Stop working whole app
            ThrowEx.Custom("");
            
        }
        public async void AsyncVoidExceptions_CannotBeCaughtByCatch()
        {
            try
            {
                await ThrowExceptionAsync();
            }
            catch (Exception ex)
            {
                // The exception is never caught here!
                throw;
            }
        }
    }
}
