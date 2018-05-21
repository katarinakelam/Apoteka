using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka.BLL.BusinessCommands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Container container;

        public CommandProcessor(Container container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public void Process(ICommand command)
        {
            var handlerType =
                typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = container.GetInstance(handlerType);

            handler.Handle((dynamic)command);
        }
    }
}