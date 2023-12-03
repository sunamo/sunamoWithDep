namespace dcomartin.Demo.AsyncAwaitExceptions
{
    // https://codeopinion.com/handling-async-await-exceptions/
    class CodeOpinionCom
    {
static Type type = typeof(CodeOpinionCom);
        static void Run(List<string> args)
        {
            // Since main entry does not support async, lets create a async task.
            Task.Run(async () =>
            {
                var demo = new AsyncDemo();
                // Exception thrown will be swallowed
                demo.MethodCalledWithoutAwait();
                // Exception will be raised
                await demo.MethodCalledWithAwait();
            }).Wait();
        }
    }
    public class AsyncDemo
    {
        static Type type = typeof(AsyncDemo);
        public void MethodCalledWithoutAwait()
        {
            // Although this method throws an exception, because we are not awaiting it,
            // it will be swallowed and will not be caught.
            AsyncMethodException();
        }
        public async Task MethodCalledWithAwait()
        {
            // Because we are awaiting the async method, the exception thrown will be raised.
            await AsyncMethodException();
        }
        public async Task AsyncMethodException()
        {
            // This method would do some async call (possible IO).
            // For the example, we will throw an exception to show as an example how\
            // the exception will be swollowed by not calling await. 
            ThrowEx.Custom("");
        }
    }
}
