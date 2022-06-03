using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Core.Countries.Commands
{
    public class AddContryCommand : ICommand
    {
        public string Name { get; private set; }

        public AddContryCommand(string name)
        {
            Name = name;
        }
    }
}
