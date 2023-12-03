namespace AsyncExceptions
{
    class S041815236
    {
static Type type = typeof(S041815236);
        /// <summary>
        /// Can return Task or void, be async or anything else, have await... 
        /// But is have ContinueWith() throw exceptions on place of occuring
        /// </summary>
        /// <param name="args"></param>
        public async static Task Run(List<string> args)
        {
            await TestTaskAsyncInLambdaAsync().ContinueWith(t =>
            {
                Debug.WriteLine(t.Exception.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);
            //Debug.ReadKey();
        }
        static async Task<IEnumerable<string>> TestTaskAsyncInLambdaAsync()
        {
            IEnumerable<string> list = null;
            try
            {
                list = await TestTaskAsyncInLambda();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught!");
            }
            Debug.WriteLine("Caller");
            if (list == null)
            {
                return new List<string>();
            }
            return list;
        }
        static async Task<IEnumerable<string>> TestTaskAsyncInLambda()
        {
            var task = new Task<IEnumerable<string>>( () =>
            {
                // 
                //
                //Task.Delay(1500).ConfigureAwait(false);
                ThrowEx.Custom("");
                return null;
            });
            //WPF: If will be here, task never start(Start() method is below) and whole app closes
            //ThrowEx.Custom(AggregateException("This is a test");
            task.Start();
            await Task.Delay(1500);
            var result = await task;
            
            //ThrowEx.Custom(AggregateException("This is a test");
            return result;
        }
        //KO
        static async Task<IEnumerable<string>> TestTaskAsync()
        {
            IEnumerable<string> list = null;
            try
            {
                list = await TestTaskAsyncInLambda();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught!");
            }
            Debug.WriteLine("Caller");
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        static Task<IEnumerable<string>> TestTask()
        {
            var task = new Task<IEnumerable<string>>(() =>
            {
                ThrowEx.Custom("");
                return null;
            });
            task.Start();
            Task.Delay(1000);
            return task;
        }
    }
}
