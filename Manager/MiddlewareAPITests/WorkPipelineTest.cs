using MiddlewareAPI.Core;
using MiddlewareAPI.CommandSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiddlewareAPITests
{
    [TestClass]
    public class WorkPipelineTest
    {
        private const string VALUE_VARIABLE_NAME = "Value";

        public class SummCommand : ICommand
        {
            public DataContainer Data { get; set; }

            public SummCommand()
            {
                Data = new DataContainer();
            }

            public DataContainer Work()
            {
                DataContainer result = new DataContainer();

                float summ = 0;

                foreach (string arg in Data.GetObject<string[]>("Args"))
                    if (float.TryParse(arg, out float value))
                        summ += value;

                result.SetObject(VALUE_VARIABLE_NAME, summ);

                return result;
            }
        }

        public class ResponseBuilder : IResponseBuilder
        {
            private Request response;

            public void BuildResponse(DataContainer data)
            {
                response = new Request(data.GetObject<string>(VALUE_VARIABLE_NAME));
            }

            public Request GetResponse()
            {
                return response;
            }
        }


        [TestMethod]
        public void CoreTest()
        {
            var commandExample = new SummCommand();
            var builderExample = new ResponseBuilder();
            var pipelineExample = new CommandResponsePipeline();

            RequestWorker workerExample = new RequestWorker("summ", pipelineExample, commandExample, builderExample);

            RequestWorkerSet workerSet = new RequestWorkerSet();
            workerSet.AddRequestWorkers(workerExample);

            WorkCore core = new WorkCore(workerSet);
            core.Run("summ:10,20");

            Assert.AreEqual("30", commandExample.Work().GetObject<string>(VALUE_VARIABLE_NAME));
            Assert.AreEqual("30", builderExample.GetResponse().Value);
        }
    }
}
