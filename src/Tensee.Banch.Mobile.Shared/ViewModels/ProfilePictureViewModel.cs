using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Tensee.Banch.Core.Threading;
using Tensee.Banch.ViewModels.Base;
using Xamarin.Forms;

namespace Tensee.Banch.ViewModels
{
    public class ProfilePictureViewModel : XamarinViewModel
    {
        public ICommand CloseCommand => AsyncCommand.Create(NavigationService.CloseModalAsync);

        private ImageSource _photo;

        public ImageSource Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                RaisePropertyChanged(() => Photo);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var profilePictureBytes = (byte[])navigationData;
            Photo = ImageSource.FromStream(() => new MemoryStream(profilePictureBytes));
            return Task.CompletedTask;
        }
    }
}
