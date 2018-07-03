using Xamarin.Forms.Internals;

namespace Tensee.Banch.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}