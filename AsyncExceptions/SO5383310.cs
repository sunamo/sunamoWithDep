namespace AsyncExceptions
{
    class SO5383310
    {
static Type type = typeof(SO5383310);
        public async void DoFoo()
        {
            try
            {
                await Foo();
            }
            catch (Exception ex)
            {
                // Show lines where occured: Async exception at AsyncExceptions.SO5383310.DoSomethingAsync() in D:\vs\sunamo.Tests\AsyncExceptions\SO5383310.cs:line 52
                Debugger.Break();
                // The exception will be caught because you've awaited
                // the call in an async method.
            }
        }
        //or//
        public void DoFoo2()
        {
            try
            {
                Foo().Wait();
            }
            catch (Exception ex)
            {
                Debugger.Break();
                /* The exception will be caught because you've
                   waited for the completion of the call. */
            }
        }
        public async Task Foo()
        {
            var x = await DoSomethingAsync();
            /* Handle the result, but sometimes an exception might be thrown.
               For example, DoSomethingAsync gets data from the network
               and the data is invalid... a ProtocolException might be thrown. */
        }
        private Task<string> DoSomethingAsync()
        {
            ThrowEx.Custom("Async exception");
            return null;
        }
    }
}
