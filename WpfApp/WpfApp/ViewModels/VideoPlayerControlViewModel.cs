using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Components;

namespace WpfApp.ViewModels
{
    public class VideoPlayerControlViewModel : BaseViewModel
    {
        private Uri _videoSource;

        public Uri VideoSource
        {
            get => _videoSource;
            set
            {
                _videoSource = value;
                OnPropertyChanged(nameof(VideoSource));
            }
        }


        public VideoPlayerControlViewModel()
        {
            // Load video path from resources
            string fullPath = Resource.PWD(Resource3.PublicTransport_mp4);
            VideoSource = new Uri(fullPath, UriKind.RelativeOrAbsolute);
        }
      
    }
}
