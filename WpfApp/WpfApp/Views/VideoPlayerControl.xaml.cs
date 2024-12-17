using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WpfApp.Components;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for VideoPlayerControl.xaml
    /// </summary>
    public partial class VideoPlayerControl : UserControl
    {
        private VideoPlayerControlViewModel viewModel;
        public VideoPlayerControl()
        {
            InitializeComponent();
            //string fullPath = Resource.PWD(Resource3.PublicTransport_mp4);
            viewModel = (VideoPlayerControlViewModel)DataContext;
            //videoPlayer.Source = new Uri(fullPath, UriKind.RelativeOrAbsolute);
            viewModel.RegisterMediaElement(videoPlayer);
            //videoPlayer.Play();
        }
        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Restart the video from the beginning
            string fullVideoPath = Resource.PWD(Resource3.PublicTransport_mp4);
            videoPlayer.Source = new Uri(fullVideoPath, UriKind.RelativeOrAbsolute);
            videoPlayer.Position = TimeSpan.Zero;
            videoPlayer.Play();
        }

        //private void VideoPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        //{
        //    MessageBox.Show("Failed to load video: " + e.ErrorException.Message);
        //}

        //private void VideoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Video loaded successfully.");
        //}
        //private void PlayVideo()
        //{
        //    videoPlayer.Play();
        //}

        //private void PauseVideo()
        //{
        //    videoPlayer.Pause();
        //}

        //private void StopVideo()
        //{
        //    videoPlayer.Stop();
        //}
    }
}
