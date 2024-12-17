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
        private MediaElement _mediaElement;
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

        public ICommand PlayCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand StopCommand { get; }

        public VideoPlayerControlViewModel()
        {
            // Load video path from resources
            string fullPath = Resource.PWD(Resource3.PublicTransport_mp4);
            VideoSource = new Uri(fullPath, UriKind.RelativeOrAbsolute);

            // Initialize commands
            PlayCommand = new RelayCommand(PlayVideo);
            PauseCommand = new RelayCommand(PauseVideo);
            StopCommand = new RelayCommand(StopVideo);
        }
        public void RegisterMediaElement(MediaElement mediaElement)
        {
            _mediaElement = mediaElement;
        }

        private void PlayVideo(object obj)
        {
            _mediaElement?.Play();
        }

        private void PauseVideo(object obj)
        {
            _mediaElement?.Pause();
        }

        private void StopVideo(object obj)
        {
            _mediaElement?.Stop();
        }
    }
}
